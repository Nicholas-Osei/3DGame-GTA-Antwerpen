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
    public EnemySpawn EnemySpawn;

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
        if (timeStart <= 0)
        {
            faseNr++;
            switch (faseNr)
            {
                case 1:
                    Enemy.speed = 4.0f;
                    message.text = "Fase " + faseNr + " has started, get 10 RP!";
                    fase.text = "Fase " + faseNr;
                        
                    timeStart = 120;
                    break;

                case 2:
                    Enemy.speed = 6.0f;
                    message.text = "Fase " + faseNr + " has started, get 30 RP!";
                    fase.text = "Fase " + faseNr;
                    //if (timeStart == 0)
                    //    faseNr++;
                    timeStart = 150;
                    StartCoroutine(EnemySpawn.EnemiesSpawning(30));
                    break;

                case 3:
                    Enemy.speed = 8.0f;
                    message.text = "Fase " + faseNr + " has started, get 50 RP!";
                    fase.text = "Fase " + faseNr;
                    //if (timeStart ==0)
                    //    faseNr++;
                    timeStart = 180;
                    StartCoroutine(EnemySpawn.EnemiesSpawning(30));
                    break;

                case 4:
                    Enemy.speed = 10.0f;
                    message.text = "Fase " + faseNr + " has started, get 70 RP!";
                    fase.text = "Fase " + faseNr;
                    //if (timeStart == 0)
                    //    faseNr++;
                    timeStart = 210;
                    StartCoroutine(EnemySpawn.EnemiesSpawning(50));
                    break;

                case 5:
                    Debug.Log("Game over");
                    Application.Quit();
                    break;
            }
        }
    }
}
