using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class Analytics : MonoBehaviour
{
    private static Analytics _instance;
    public static Analytics Instance => _instance;
    private static string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfLfIRwunJG9nUus3WXeJWMM6aAFiVS6xnJ4xDz3-FyPuxNHg/formResponse";
    private SaveObject saveObject;
    private long sessionID;
    private string applicationVersion;
    private string poweruptime=" ";
    
    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        saveObject = new SaveObject();
        sessionID = DateTime.Now.Ticks;
        applicationVersion = Application.version;
        string firstpowerup = "";
        SetGuidIfNotSet();
    }
    private void SetGuidIfNotSet()
    {
        if (!PlayerPrefs.HasKey("GUID"))
        {
            PlayerPrefs.SetString("GUID", System.Guid.NewGuid().ToString());
        }
    }
    public void SetAttemptStopwatch(Stopwatch sw)
    {
        saveObject.attemptStopwatch = sw;
    }

    public void SetLevelName(string level)
    {
        saveObject.level = level;
    }

    public void RecordLevelRestart()
    {
        saveObject.restarts++;
    }

    public int GetRestarts()
    {
        return saveObject.restarts;
    }
    public void RecordPowerup()
    {
        saveObject.powerup++;
    }

    public int GetPowerup()
    {
        return saveObject.powerup;
    }

    public void RecordObstacle()
    {
        saveObject.obstacle++;
    }

    public int GetObstacle()
    {
        return saveObject.obstacle;
    }

    public void RecordSingleFlags()
    {
        saveObject.singleFlag++;
    }

    public int GetSingleFlags()
    {
        return saveObject.singleFlag;
    }

    public String GetLevel()
    {
        return saveObject.level;
    }

    public void RecordFirstpoweruptime(){
        poweruptime = saveObject.attemptStopwatch.Elapsed.TotalSeconds.ToString("F");
    }

    public void Recordpowerupname(string name){
        saveObject.powerupname += name;
    }

    public String Getpowerupname(){
        return saveObject.powerupname;
    }

    public void Save()
    {
        saveObject.attemptStopwatch.Stop();
        string totalTime = saveObject.attemptStopwatch.Elapsed.TotalSeconds.ToString("F");

        SetLevelName(SceneManager.GetActiveScene().name);
        StartCoroutine(Post(sessionID, totalTime, poweruptime));
        ResetSaveObject();
    }

    public void ResetSaveObject()
    {
        saveObject.restarts = 0;
        saveObject.attemptStopwatch.Restart();
        saveObject.singleFlag = 0;
        saveObject.powerup = 0;
        saveObject.obstacle =0;
        saveObject.powerupname = " ";

    }

    private IEnumerator Post(long sessionID, string totalTime,string firstpowerup)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.942059168", sessionID.ToString());
        form.AddField("entry.1810727681", saveObject.level);
        form.AddField("entry.919607293", totalTime);
        form.AddField("entry.1578023229", saveObject.restarts);
        form.AddField("entry.628357750", saveObject.singleFlag);
        form.AddField("entry.728399791", saveObject.powerup);
        form.AddField("entry.587566253", saveObject.obstacle);
        form.AddField("entry.236424767", firstpowerup);
        form.AddField("entry.1150497477", saveObject.powerupname);
        form.AddField("entry.768846161", PlayerPrefs.GetString("GUID"));
        
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload completed");
                Debug.Log("__________________________________________");
            }
        }
    }
}