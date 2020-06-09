using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;
    public Transform car;
    private EnterCar enterCar = new EnterCar();
    public bool FollowPlayer;
    // Start is called before the first frame update
    void LateUpdate()
    {
        Vector3 newPosition;
        if(FollowPlayer)
        {
            newPosition = player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;

            transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
        }
        else
        {
            newPosition = car.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;

            transform.rotation = Quaternion.Euler(90f, car.eulerAngles.y, 0f);
        }
        
    }
}
