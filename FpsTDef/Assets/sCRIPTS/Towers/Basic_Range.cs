using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Base_Tower_Range : MonoBehaviour
{
   
    public GameObject projectile;
    public AudioSource weaponSpeaker;
    public Transform firePoint;
    private Camera firingDirection;

    [Header("Meta Attributes")]
    public bool canFire = true;
    public bool reloading = false;
    public int weaponID;
    public string weaponName;

    [Header("Tower Stats")]
    public float projLifespan;
    public float projVelocity;
    public float reloadCooldown;
    public float rof;
    public int fireModes;
    public int currentFireMode;
    public int clip;
    public int clipSize;
    

    [Header("Ammo Stats")]
    public int ammo = 99999999;
    public int maxAmmo = 99999999;    



    void Start()
    {
        weaponSpeaker.Play();
        firingDirection = Camera.main;
        weaponSpeaker = GetComponent<AudioSource>();
        firePoint = transform.GetChild(0);
    }

    private void OnTriggerEnter(Collider other)
    { 
            if (other.CompareTag("enemy")) 
            {
                canFire = true;
                Debug.Log("Video ergo cogito.");
                GameObject p = Instantiate(projectile, firePoint.position, firePoint.rotation);
                p.GetComponent<Rigidbody>().AddForce(firingDirection.transform.forward * projVelocity);
                Destroy(p, projLifespan);
                clip--;
                StartCoroutine("cooldownFire");
            }
    }
    
    
    public void reload()
    {
        if (clip >= clipSize)
            return;

        else
        {
            int reloadCount = clipSize - clip;

            if (ammo < reloadCount)
            {
                clip += ammo;
                ammo = 0;
            }

            else
            {
                clip += reloadCount;
                ammo -= reloadCount;
            }

            reloading = true;
            canFire = false;
            StartCoroutine("reloadingCooldown");
            return;
        }
    }

    IEnumerator cooldownFire()
    {
        yield return new WaitForSeconds(rof);

        if (clip > 0)
            canFire = true;
    }

    IEnumerator reloadingCooldown()
    {
        yield return new WaitForSeconds(reloadCooldown);

        reloading = false;
        canFire = true;
    }
}