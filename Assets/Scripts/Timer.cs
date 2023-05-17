using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GelatoVideoManager GelatoVideoManager;
    public TextMeshProUGUI timetext;
    float timer;
    float MAXTIME = 35f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.touchCount > 0 )
        {
            timer = 0;
        }
        if(timer > MAXTIME)
        {
            GelatoVideoManager.initializeGelato();
            timer = 0;
        }
        timetext.text = "time: " + timer.ToString();
    }

    public void setTimeZero()
    {
        timer = 0;
    }
}
