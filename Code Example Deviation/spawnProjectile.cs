using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnProjectile : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bullet;
    public ParticleSystem muzzle;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("bulletSpawn", 1f, 3f);
    }

    // make Bullet spawn from the firePoint to a forward speed
    void bulletSpawn()
    {
        Vector3 forwardVector = this.transform.rotation * Vector3.forward;
        GameObject currentBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.identity); //store instantiated bullet in currentBullet

        currentBullet.transform.forward = forwardVector.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(forwardVector.normalized * bulletSpeed, ForceMode.Impulse);
        if (muzzle != null)
            muzzle.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
