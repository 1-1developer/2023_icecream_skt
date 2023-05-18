using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameObject debugwindow;
    float timer;
    int cnt;
    int cnt2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            debugwindow.SetActive(true);
        }
    }

    public void Ondebug()
    {
        debugwindow.SetActive(true);
    }
    public void Quitthis()
    {
        Application.Quit();
    }
}
