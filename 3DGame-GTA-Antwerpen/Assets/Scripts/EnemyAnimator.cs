using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public Animator animator;
    public float InputY;
    public float InputX;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputY = Input.GetAxis("Vertical");
        animator.SetFloat("InputY", InputY);
        InputY = Input.GetAxis("Horizontal");
        animator.SetFloat("InputX", InputX);
    }
}
