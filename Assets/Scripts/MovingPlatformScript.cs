using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public Transform posA, posB;
    public float Speed; // Change Speed to float, since it's used with Time.deltaTime
    Vector2 targetPos;

    void Start()
    {
        targetPos = posB.position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.1f) // Corrected the threshold value
        {
            targetPos = posB.position;
        }

        if (Vector2.Distance(transform.position, posB.position) < 0.1f) // Corrected to check distance from posB
        {
            targetPos = posA.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime); // Corrected "tranform" to "transform"
    }
    private void OnTriggerEnter2D (Collider2D collision)

	{
		if (collision.CompareTag("Ball1"))
		{

			collision.transform. SetParent(this.transform);
		}
	}

	public void OnTriggerExit2D (Collider2D collision)

	{
		if (collision.CompareTag("Ball1"))

		{

		collision.transform.SetParent(null);
		}
	}
}
