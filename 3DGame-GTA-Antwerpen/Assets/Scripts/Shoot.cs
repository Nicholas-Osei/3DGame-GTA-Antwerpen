using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public float Damage = 5;
    public int GunRange = 100;

    [SerializeField]
    [Range(0.05f,1f)]
    public float FireRate = 1;

    private KeyCode Mouse1 = KeyCode.Mouse0;


    public GameObject[] ParticleExamples;
    private int exampleIndex;

    public bool orderedSpawns = true;
    public float step = 1.0f;
    public float range = 5.0f;
    private float order = -5.0f;
    private string randomSpawnsDelay = "0.5";

    [SerializeField]
    private AudioSource GunSound;

    //LineDraw
    private Camera thrirdCamera;
    private WaitForSeconds Duration = new WaitForSeconds(0.9f);
    public LineRenderer laserline;
    private float nextFire;


    private float timer;
    public Transform firePoint;

    private void Start()
    {
        laserline = GetComponent<LineRenderer>();
        Cursor.lockState = CursorLockMode.Locked;

    }

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

    void FireGun()
    {
        GameObject particle = spawnParticle();
        particle.transform.position = particle.transform.position;
        GunSound.Play();

        Debug.DrawRay(firePoint.position, firePoint.forward * GunRange, Color.red, 2f);

        nextFire = Time.time + FireRate;
        

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitinfo;

        //laserline.SetPosition(0, firePoint.position);
        //ShotEffect();

        if (Physics.Raycast(ray, out hitinfo, GunRange))
        {
            //laserline.SetPosition(1, hitinfo.point);
            Destroy(hitinfo.collider.gameObject);
        }

    }   

    private IEnumerable ShotEffect()
    {
        laserline.enabled = true;
        yield return Duration;
        laserline.enabled = false;

    }

    private GameObject spawnParticle()
    {
        GameObject particles = (GameObject)Instantiate(ParticleExamples[exampleIndex]);
        particles.transform.parent = ParticleExamples[exampleIndex].transform.parent;
        particles.transform.localPosition = ParticleExamples[exampleIndex].transform.localPosition;
        particles.transform.localRotation = ParticleExamples[exampleIndex].transform.localRotation;

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
