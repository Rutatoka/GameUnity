using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
 
    public Text timerText;

    public float timeStart = 0 ;

    void Start()
    {
        timerText.text = timeStart.ToString("F2");
    }
    void Update()
    {
        timeStart += Time.deltaTime;
        timerText.text = timeStart.ToString("F2");
    }
}
