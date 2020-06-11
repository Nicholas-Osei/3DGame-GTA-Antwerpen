using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    HeroHealth heroHealth;
    public HealthBar healthbar;

    public float healthBonus = 100f;
    public void Awake()
    {
        heroHealth = FindObjectOfType<HeroHealth>();
    }
    public void OnTriggerEnter(Collider coll)
    {
        if(heroHealth.currentHealth < heroHealth.startHealth)
        {
            Destroy(gameObject);
            heroHealth.currentHealth = heroHealth.currentHealth + healthBonus;
            healthbar.SetHealth(heroHealth.currentHealth);
        }
    }
}
