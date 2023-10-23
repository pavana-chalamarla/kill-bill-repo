using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneicObj : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ball;
    public float attractionSpeed = 5f;
    public bool isAttracting = false;

    // Update is called once per frame
    void Update()
    {
        if (isAttracting)
        {
            transform.position = Vector3.MoveTowards(transform.position, ball.position, attractionSpeed * Time.deltaTime);
        }
    }
}
