using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroHealth : MonoBehaviour
{
    public float heroHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = heroHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
            Death();
    }
    private void OnEnable()
    {
        
        healthBar.SetMaxHealth(heroHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Death()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
