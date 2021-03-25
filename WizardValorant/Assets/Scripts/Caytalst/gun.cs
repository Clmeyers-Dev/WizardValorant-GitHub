using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage =10f;
    public float range = 100f;
    public float fireRate = 15f;
    public GameObject impactEffect;
    private float nextTimeToFire = 0f;
    public Camera FPSCam;
    public SC_FPSController controller;
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject effecttoSpawn;
    public bool Automatic;
    public LayerMask myLayerMask;
    public WizardManager wizardManager;
    private void Start()
    {
        wizardManager = GetComponentInParent<WizardManager>();
        effecttoSpawn = vfx[0];
        FPSCam = GetComponentInParent<Camera>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1")&&Time.time>= nextTimeToFire&Automatic ==true)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        
        GameObject vfx;
        if (firePoint != null)
        {
            vfx = Instantiate(effecttoSpawn, firePoint.transform.position, Quaternion.identity);
            vfx.transform.localRotation = firePoint.transform.rotation;
        }

        RaycastHit hit;
       if( Physics.Raycast(wizardManager.loadPostion.transform.position, FPSCam.transform.forward, out hit, range,myLayerMask))
        {
            Debug.Log("hit "+ hit.transform.name);
            HealthManager target=  hit.transform.GetComponentInParent<HealthManager>();

            if (target != null)
            {
               
                target.TakeDamage(damage);
            
            }
        GameObject  impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
