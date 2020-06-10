using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;

    public int PositionX, PostionZ, AantalEnemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemiesSpawning());
    }

    IEnumerator   EnemiesSpawning()
    {
        while (AantalEnemies<10)
        {
            PositionX = UnityEngine.Random.Range(-3,500);
            PostionZ = UnityEngine.Random.Range(1,600);
            Instantiate(Enemy, new Vector3(PositionX, 0.2f, PostionZ), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            AantalEnemies++;

        }
    }

    
}
