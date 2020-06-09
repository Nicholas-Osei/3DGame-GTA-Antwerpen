using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class ExitCar : MonoBehaviour
{
    public GameObject CarCam;
    public GameObject PlayerCam;
    public GameObject Player;
    public GameObject ExitTrigger;
    public GameObject Car;
    public GameObject ExitPlace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            Player.SetActive(true);
            Player.transform.position = ExitPlace.transform.position;
            CarCam.SetActive(false);
            PlayerCam.SetActive(true);
            Car.GetComponent<CarUserControl>().enabled = false;
            Car.GetComponent<CarController>().enabled = false;
            ExitTrigger.SetActive(false);
        }
    }
}
