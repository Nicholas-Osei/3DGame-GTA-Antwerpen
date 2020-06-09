using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class EnterCar : MonoBehaviour
{
    public GameObject CarCam;
    public GameObject PlayerCam;
    public GameObject Player;
    public GameObject ExitTrigger;
    public GameObject Car;
    public int TriggerCheck = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (TriggerCheck)
        {
            case 1:
                if (Input.GetButtonDown("Action"))
                {
                    CarCam.SetActive(true);
                    PlayerCam.SetActive(false);
                    Player.SetActive(false);
                    Car.GetComponent<CarController>().enabled = true ;
                    Car.GetComponent<CarUserControl>().enabled = true;
                    ExitTrigger.SetActive(true);
                }
                break;
        }
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        TriggerCheck = 1;
        System.Console.WriteLine("Trigger = 1");
    }
    public void OnTriggerExit(Collider collider)
    {
        TriggerCheck = 0;
        System.Console.WriteLine("Trigger = 0");
    }
}
