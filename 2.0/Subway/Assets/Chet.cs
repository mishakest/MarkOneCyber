using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chet : MonoBehaviour
{
    public Text text;
    float x = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x +=  Time.deltaTime * 3;
        text.text = ((int)x).ToString();
    }
}
