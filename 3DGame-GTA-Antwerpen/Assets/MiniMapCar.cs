using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCar : MonoBehaviour
{
    public Transform car;
    // Start is called before the first frame update
    void LateUpdate()
    {
        Vector3 newPosition = car.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, car.eulerAngles.y, 0f);
    }
}
