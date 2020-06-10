using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public float Damage = 1;
    public int GunRange = 100;

    [SerializeField]
    [Range(0.05f,1f)]
    public float FireRate = 1;

    public GameObject ParticleExamples; 

    public bool orderedSpawns = true;
    public float step = 1.0f;
    public float range = 5.0f;
    private float order = -5.0f;
    private string randomSpawnsDelay = "0.5";
    public float enemyHealth = 100;
    public float currentHealth;

    [SerializeField]
    private AudioSource GunSound;


    private float timer;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= FireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                
                timer = 0f;
                FireGun();
            }
            
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    void FireGun()
    {
        GameObject particle = spawnParticle();
        particle.transform.position = particle.transform.position;
        GunSound.Play();
        
        
        Debug.DrawRay(firePoint.position, firePoint.forward * 300, Color.red, 2f);

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitinfo;
        
        if(Physics.Raycast(ray, out hitinfo, range))
        {
            var enHealth = hitinfo.collider.GetComponent<EnemyHealth>();
            if (enHealth != null)
                enHealth.TakeDamage(Damage);
        }
    }

    private GameObject spawnParticle()
    {
        GameObject particles = (GameObject)Instantiate(ParticleExamples);
        particles.transform.parent = ParticleExamples.transform.parent;
        particles.transform.localPosition = ParticleExamples.transform.localPosition;
        particles.transform.localRotation = ParticleExamples.transform.localRotation;

        SetActiveCrossVersions(particles, true);

        return particles;
    }

    void SetActiveCrossVersions(GameObject obj, bool active)
    {
        #if UNITY_3_5
				obj.SetActiveRecursively(active);
        #else
        obj.SetActive(active);
        for (int i = 0; i < obj.transform.childCount; i++)
            obj.transform.GetChild(i).gameObject.SetActive(active);
        #endif
    }

    IEnumerator RandomSpawnsCoroutine()
    {

    LOOP:
        GameObject particles = spawnParticle();

        if (orderedSpawns)
        {
            particles.transform.position = this.transform.position + new Vector3(order, particles.transform.position.y, 0);
            order -= step;
            if (order < -range) order = range;
        }
        else particles.transform.position = this.transform.position + new Vector3(Random.Range(-range, range), 0,Random.Range(-range, range)) + new Vector3(0, particles.transform.position.y, 0);

        yield return new WaitForSeconds(float.Parse(randomSpawnsDelay));

        goto LOOP;
    }
}
