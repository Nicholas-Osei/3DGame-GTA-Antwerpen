using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Transform Player;
    private Rigidbody rigidbody;
    public float InputX;
    public float InputY;
    public float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FixedUpdate()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.fixedDeltaTime);
        animator.SetFloat("InputX", Player.position.x);
        animator.SetFloat("InputY", Player.position.y);
        rigidbody.MovePosition(position);
        transform.LookAt(Player);
    }
}
   
