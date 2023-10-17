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

    public void RecordSingleFlags(bool ball1Entered, bool ball2Entered)
    {
        if ((ball1Entered && !ball2Entered))
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
    

    public void Save()
    {
        saveObject.attemptStopwatch.Stop();
        string totalTime = saveObject.attemptStopwatch.Elapsed.TotalSeconds.ToString("F");

        SetLevelName(SceneManager.GetActiveScene().name);
        StartCoroutine(Post(sessionID, totalTime));
        ResetSaveObject();
    }

    public void ResetSaveObject()
    {
        saveObject.restarts = 0;
        saveObject.attemptStopwatch.Restart();
        saveObject.singleFlag = 0;
    }

    private IEnumerator Post(long sessionID, string totalTime)
    {
        WWWForm form = new WWWForm();
        //smaran form fields
        form.AddField("entry.241934467", sessionID.ToString());
        form.AddField("entry.1140738487", saveObject.level);
        form.AddField("entry.1008519031", totalTime);
        form.AddField("entry.671951769", saveObject.restarts);
        form.AddField("entry.1712601863", saveObject.singleFlag);
        
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