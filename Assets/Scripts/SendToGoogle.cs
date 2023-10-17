using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SendToGoogle : MonoBehaviour
{
    [SerializeField] private string URL;
    private long _sessionID;
    private int _levelNumber;
    private float _timeTaken;
    private int _restartCount;

    private void Awake()
    {
        _sessionID = DateTime.Now.Ticks;
        _levelNumber = 0; // Example: starting at level 1
        _timeTaken = 0f;
        Send();
    }

    private void Start()
    {
        // You may want to call Send in Start or elsewhere based on your requirements.
        // Send();
    }

    private void Update()
    {
        // Update logic here if needed
    }

    public void Send()
    {
        // Assign variables
        _levelNumber++;
       _timeTaken = Time.time; // Capture the starting time of the level


        StartCoroutine(Post(
            _sessionID.ToString(),
            _levelNumber.ToString(),
            _timeTaken.ToString()
        ));
    }

    private IEnumerator Post(string sessionID, string levelNumber, string timeTaken)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.241934467", sessionID);
        form.AddField("entry.1140738487", levelNumber);
        form.AddField("entry.1008519031", timeTaken);

        // Send responses and verify result
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
