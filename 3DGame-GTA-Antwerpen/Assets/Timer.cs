using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public Text fase;
    public Text message;
    public Image messageBg;

    public static int faseNr = 1;
    public static float timeStart = 120;
    private static System.Timers.Timer timer_t;
    // Start is called before the first frame update
    void Start()
    {
      //  timer = GetComponent<Text>();
        //fase = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        timer.text = Mathf.Round(timeStart).ToString();
        switch (Timer.faseNr)
        {
            case 1:
                Enemy.speed = 4.0f;
                message.text = "Fase " + faseNr + " has started, get 10 RP!";
                if (ScoreScript.scoreValue == 10)
                {
                    faseNr++;
                    fase.text = "Fase " + faseNr;
                    timeStart = 120;
                }
                break;
            case 2:
                Enemy.speed = 6.0f;
                message.text = "Fase " + faseNr + " has started, get 30 RP!";
                if (ScoreScript.scoreValue == 30)
                {
                    faseNr++;
                    fase.text = "Fase " + faseNr;
                    timeStart = 150;
                }
                break;
            case 3:
                Enemy.speed = 8.0f;
                message.text = "Fase " + faseNr + " has started, get 50 RP!";
                if (ScoreScript.scoreValue == 50)
                {
                    faseNr++;
                    fase.text = "Fase " + faseNr;
                    timeStart = 180;
                }
                break;
            case 4:
                Enemy.speed = 10.0f;
                message.text = "Fase " + faseNr + " has started, get 70 RP!";
                if (ScoreScript.scoreValue == 70)
                {
                    faseNr++;
                    fase.text = "Fase " + faseNr;
                    timeStart = 210;
                }
                break;
            case 5:
                Debug.Log("Game over");
                Application.Quit();
                break;
        }
    } 
}
