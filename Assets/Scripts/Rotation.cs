using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 10.0f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
    }
      
}


 
