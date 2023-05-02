using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public GameObject muzzleFlash;
    public AudioSource gunShot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        muzzleFlash.SetActive(true);
        gunShot.PlayOneShot(gunShot.clip, 1);
        RaycastHit infoHit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out infoHit, range))
        {
            ZombieScript target = infoHit.transform.GetComponent<ZombieScript>();
            if (target != null)
            {
                target.zombieTakeDamage(damage);
            }
        }
        Invoke("muzzfla", 0.15f);
        
    }
    public void muzzfla()
    {
        muzzleFlash.SetActive(false);
    }
}
