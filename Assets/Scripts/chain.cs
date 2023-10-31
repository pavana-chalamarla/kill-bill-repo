using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// public mirror mirrorScript;

public class chain : MonoBehaviour
{
  
    // Start is called before the first frame update
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
private void OnTriggerEnter2D (Collider2D other)
    {
          mirror script = GetComponent<mirror>();

Debug.Log(other.gameObject.name);

        // if (other.gameObject.CompareTag("Mirror"))
        // {
        //     Debug.Log("mirror coll");
        // }


        if (other.gameObject.name =="chain")
        {
           

            
            Debug.Log("chain cut");
            //  mirrorScript.ToggleDirection();
        // script.s();
            // script.enabled = false;


            //ChangeFlagColor(Color.green);
           // ball1Entered = true;
          //  CheckCollisions();
        }
    }
    
}
