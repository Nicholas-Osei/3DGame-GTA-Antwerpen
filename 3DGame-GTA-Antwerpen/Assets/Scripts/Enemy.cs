    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Transform Player;
    private Rigidbody rigidbody;
    public float Kick;
    public float speed = 4f;
    public float Position;

    public float heroHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    public bool damage;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        rigidbody = this.GetComponent<Rigidbody>();
        currentHealth = heroHealth;
        healthBar.SetMaxHealth(heroHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FixedUpdate()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.fixedDeltaTime);
        Vector3 Direction = transform.position;

        float close = (transform.position - Player.position).sqrMagnitude;


        if (close <= 5)
        {
            Debug.Log("i am close");
            //animator.SetBool("IsKicking", true);
            animator.SetBool("IsPunching", true);
     
        }
        else
        {
            animator.SetBool("IsPunching", false);
        }
        if(animator.GetBool("IsPunching") == true)
        {
            TakeDamage(0.1f);
            Debug.Log("Take damage");

        }

       
        animator.SetBool("IsWalking", true);

        rigidbody.MovePosition(position);
        transform.LookAt(Player);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
