using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneicObj : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ball;
    public float attractionSpeed = 1f;
    public bool isAttracting = false;

    // Update is called once per frame
    void Update()
    {
        if (isAttracting)
        {

            Vector3 newPosition = transform.position;
            newPosition.x = Mathf.MoveTowards(transform.position.x, ball.position.x, attractionSpeed * Time.deltaTime);
            transform.position = newPosition;
            //transform.position = Vector3.MoveTowards(transform.position, ball.position, attractionSpeed * Time.deltaTime);
        }
    }
}
