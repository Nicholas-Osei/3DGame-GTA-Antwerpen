using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


public class Clock : MonoBehaviour
{
    private Text clock;
    public GameObject directionLightObject;
    private Light directionLight;

    public int hour = 12, minute1 = 0, minute2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        clock = GetComponent<Text>();
        directionLight = directionLightObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        minute2++;
        if (minute2 > 9)
        {
            minute2 = 0;
            minute1++;
        }
        else if (minute1 > 5)
        {
            minute1 = 0;
            hour++;
        }
        else if (hour > 23)
        {
            hour = 0;
        }
        Thread.Sleep(50);
        clock.text = hour + ":" + minute1 + minute2;

        if (directionLight)
        {
            if(hour >= 6 && hour < 18)
            {
                directionLight.color = Color.white;
            }
            else if(hour >= 18 && hour < 21)
            {
                directionLight.color = Color.yellow;
            }
            else if(hour >= 21 && hour < 24)
            {
                directionLight.color = Color.black;
            }
            else if(hour >= 0 && hour < 6)
            {
                directionLight.color = Color.black;
            }
        }
    }
}
