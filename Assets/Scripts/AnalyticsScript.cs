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
    private static string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeyIBdBXKV4-CK_MeVbmoF4Fcbtgr3EIQkpfA68xqKuXBbrJA/formResponse";
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

    public void RecordGameOver()
    {
        saveObject.gameover++;
    }

    public int GetGameOver()
    {
        return saveObject.gameover;
    }
    public void RecordSingleFlags(bool ball1, bool ball2)
    {
        if ((ball1 && !ball2))
        {
            saveObject.singleFlag++;
        }
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
        saveObject.level="";
        saveObject.restarts = 0;
        saveObject.attemptStopwatch.Restart();
        saveObject.singleFlag = 0;
        saveObject.powerup = 0;
        saveObject.obstacle =0;
        saveObject.powerupname="";
        saveObject.gameover = 0;

    }

    private IEnumerator Post(long sessionID, string totalTime,string firstpowerup)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.241934467", sessionID.ToString());
        form.AddField("entry.1140738487", saveObject.level);
        form.AddField("entry.1008519031", totalTime);
        form.AddField("entry.671951769", saveObject.restarts);
        form.AddField("entry.1712601863", saveObject.singleFlag);
        form.AddField("entry.78144186", saveObject.powerup);
        form.AddField("entry.1285814051", saveObject.obstacle);
        form.AddField("entry.373084703", firstpowerup);
        form.AddField("entry.953558190", saveObject.powerupname);
        form.AddField("entry.134935429", PlayerPrefs.GetString("GUID"));
        
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