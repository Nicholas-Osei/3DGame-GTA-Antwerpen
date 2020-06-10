using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public Text fase;
    public Text kill;
    public Text message;
    public Image messageBg;

    public static int faseNr = 1;
    public static int killNr = 0;
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
        kill.text = "Kills: " + killNr;
        switch (Timer.faseNr)
        {
            case 1:
                Enemy.speed = 4.0f;
                message.text = "Fase " + faseNr + " has started, kill 10 enemies!";
                if (ScoreScript.scoreValue == 10)
                {
                    faseNr++;
                    killNr = 0;
                    fase.text = "Fase " + faseNr;
                    timeStart = 120;
                }
                break;
            case 2:
                Enemy.speed = 6.0f;
                message.text = "Fase " + faseNr + " has started, kill 15 enemies!";
                if (ScoreScript.scoreValue == 25)
                {
                    faseNr++;
                    killNr = 0;
                    fase.text = "Fase " + faseNr;
                    timeStart = 150;
                }
                break;
            case 3:
                Enemy.speed = 8.0f;
                message.text = "Fase " + faseNr + " has started, kill 20 enemies!";
                if (ScoreScript.scoreValue == 45)
                {
                    faseNr++;
                    killNr = 0;
                    fase.text = "Fase " + faseNr;
                    timeStart = 180;
                }
                break;
            case 4:
                Enemy.speed = 10.0f;
                message.text = "Fase " + faseNr + " has started, kill 25 enemies!";
                if (ScoreScript.scoreValue == 70)
                {
                    faseNr++;
                    killNr = 0;
                    fase.text = "Fase " + faseNr;
                    timeStart = 210;
                }
                break;
        }
    } 
}
