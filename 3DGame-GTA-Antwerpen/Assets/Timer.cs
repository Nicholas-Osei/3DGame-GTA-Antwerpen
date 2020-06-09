using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public Text fase;
    public int faseNr = 1;
    public float timeStart = 10;
    private static System.Timers.Timer timer_t;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Text>();
        fase = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        timer.text = Mathf.Round(timeStart).ToString();
        if(timeStart < 0)
        {
            faseNr++;
            timeStart = 10;
            fase.text = "Fase " + faseNr;
        }
        
    } 
}
