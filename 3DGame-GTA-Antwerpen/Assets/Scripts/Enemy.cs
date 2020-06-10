    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Transform Player;
    private Rigidbody rigidbody;

    public Transform RightHand;
    public Transform LeftHand;

    public float Kick;
    public static float speed = 4f;
    public float Position;
    private bool death = false;
    public float Damage = 0.4f;
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
        if (!death) {
            Vector3 position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.fixedDeltaTime);
            Vector3 Direction = transform.position;

            Ray rayLeft = new Ray(LeftHand.position, LeftHand.forward);
            Ray RayRight = new Ray(RightHand.position, RightHand.forward);
            RaycastHit hitinfo;
            float close = (transform.position - Player.position).sqrMagnitude;


            if (close <= 5)
            {
                //Debug.Log("i am close");
                //animator.SetBool("IsKicking", true);
                animator.SetBool("IsPunching", true);

            }
            else
            {
                animator.SetBool("IsPunching", false);
            }
            if (animator.GetBool("IsPunching") == true && (Physics.Raycast(rayLeft, out hitinfo, 1) || Physics.Raycast(RayRight, out hitinfo, 1)))
            {

                //HeroHealth.TakeDamage(0.1f);
                Debug.Log("Take damage");
                var heroHealth = hitinfo.collider.GetComponent<HeroHealth>();
                if (heroHealth != null)
                    heroHealth.TakeDamage(Damage);

            }


            animator.SetBool("IsWalking", true);

            rigidbody.MovePosition(position);
            transform.LookAt(Player);
        }
    }

    public void Death()
    {
        death = true;
        animator.SetBool("Death", true);

    }

}