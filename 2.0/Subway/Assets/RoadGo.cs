using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGo : MonoBehaviour
{
    Vector3 moveVec;
    void Start()
    {
        moveVec = new Vector3(0, 0, -1);
    }

    
    void Update()
    {
        transform.Translate(moveVec * Time.deltaTime *  20);
    }
}
