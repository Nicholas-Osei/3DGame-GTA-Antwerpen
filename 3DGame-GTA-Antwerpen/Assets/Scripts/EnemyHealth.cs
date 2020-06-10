using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float startingHealth = 6;
    private float currentHealth;
    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        //gameObject.SetActive(false);
        ScoreScript.scoreValue++;
        Timer.killNr++;
        Animatie();
        yield return new WaitForSeconds(5.5f);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void Animatie()
    {

        enemy.Death();
    }


}
