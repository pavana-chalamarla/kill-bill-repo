using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isCollided : MonoBehaviour
{
    // Start is called before the first frame update
    public bool flgbool = false;

    public void SetCollisionState(bool state)
    {
        flgbool = state;
    }
   
}
