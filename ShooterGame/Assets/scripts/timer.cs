using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
 
    public Text timerText;
    private float theTime;
    public float speed = 1;

    void Start()
    {
        timerText.GetComponent<Text>();
    }
    void Update()
    {
        theTime += Time.deltaTime*speed;
        string hours = Mathf.Floor((theTime % 216000) / 3600).ToString("00");
        string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
        string seconds = (theTime % 60).ToString("00");
        timerText.text = hours + ":" + minutes + ":" + seconds;
    }
}
