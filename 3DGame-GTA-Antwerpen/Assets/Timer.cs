using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    private static System.Timers.Timer timer_t;
    public int minute = 0, second1 = 0, second2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer_t = new System.Timers.Timer();
        //timer.inter
        second2--;
        if (second2 == 0)
        {
            second2 = 9;
            second1--;
        }
        else if (second1 == 0)
        {
            second1 = 9;
            minute--;
        }
    } 
}
