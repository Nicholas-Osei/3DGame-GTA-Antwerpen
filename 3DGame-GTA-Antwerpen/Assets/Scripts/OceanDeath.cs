using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanDeath : MonoBehaviour
{
    HeroHealth hero = new HeroHealth();
    public void OnTriggerEnter(Collider coll)
    {
        hero.Death();
    }
    
}
