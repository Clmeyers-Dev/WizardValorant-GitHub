using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30;
    public float lifeTime=3;
    public int numberOfBullets;

    public float damage = 10f;

    public float fireRate = 15f;
   
    private float nextTimeToFire = 0f;
    public float ConeSize;
   public float xSpread;
   public float ySpread;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    private void Shoot()
    {
        xSpread = Random.Range(-1, 1);
        ySpread = Random.Range(-1, 1);
        Vector3 spread = new Vector3(xSpread, ySpread, 0.0f).normalized * ConeSize;
        Quaternion rotation = Quaternion.Euler(spread) * bulletSpawn.rotation;

        GameObject bullet = Instantiate(bulletPrefab,bulletSpawn.position,rotation);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bulletSpawn.parent.GetComponent<Collider>());
        
        
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestoryBulletAfterTime(bullet, lifeTime));
    }
    private IEnumerator DestoryBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }
}
