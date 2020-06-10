using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public GameObject player;
    public Camera carCam, playerCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeSelf)
        {
            playerCam.enabled = true;
            carCam.enabled = false;
        }
        else
        {
            playerCam.enabled = false;
            carCam.enabled = true;
        }
    }
}
