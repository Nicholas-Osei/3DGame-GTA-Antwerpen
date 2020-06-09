using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public float Damage = 5;
    public int range = 100;

    [SerializeField]
    [Range(0.05f,1f)]
    public float FireRate = 1;

    private KeyCode Mouse1 = KeyCode.Mouse0;

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

    void FireGun()
    {
        Debug.DrawRay(firePoint.position, firePoint.forward * 300, Color.red, 2f);
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitinfo;
        
        if(Physics.Raycast(ray, out hitinfo, range))
        {
            Destroy(hitinfo.collider.gameObject);
        }
    }
}
