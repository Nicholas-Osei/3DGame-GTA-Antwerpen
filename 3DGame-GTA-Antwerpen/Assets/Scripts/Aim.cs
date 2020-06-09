using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Aim : MonoBehaviour
{

    public float Sensitivity = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        LockCroshair();
    }

    public static void LockCroshair()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Input.mousePosition;
    }
}
