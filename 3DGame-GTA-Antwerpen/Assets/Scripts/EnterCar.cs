using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class EnterCar : MonoBehaviour
{
    public GameObject CarCam;
    public GameObject PlayerCam;
    public GameObject Player;
    public GameObject ExitTrigger;
    public GameObject Car;
    private MiniMap miniMap = new MiniMap();
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
                miniMap.FollowPlayer = false;
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
            case 0:
                miniMap.FollowPlayer = true;
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
