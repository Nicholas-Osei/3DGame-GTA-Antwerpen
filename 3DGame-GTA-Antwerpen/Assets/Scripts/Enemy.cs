using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    private Rigidbody rigidbody;
    public float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FixedUpdate()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.fixedDeltaTime);
        rigidbody.MovePosition(position);
        transform.LookAt(Player);
    }
}
   
