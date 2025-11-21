using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEngine.Rendering.DebugUI.Table;

public class Gun : MonoBehaviour
{
    PlayerContr player;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Camera directionOfFire;


    public bool mayfire = true;
    public bool relo = false;
    public bool holdAttack = true;

    public float lifespawn;
    public float velocity;
    public float reloColdown;
    public float fireRate;
    public int mag;
    public int magSize;
    public int totalAmmo;
    public int ammo;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //weaponSpeaker = GetComponent<AudioSource>();
        firePoint = transform.GetChild(0);
    }

    public void fire()
    {
        if (mayfire && !relo && mag > 0)
        {
            //weaponSpeaker.Play();
            GameObject p = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            p.GetComponent<Rigidbody>().AddForce(directionOfFire.transform.forward * velocity);
            Destroy(p, lifespawn);
            mag--;
            mayfire = false;
            StartCoroutine("cooldownFire");
        }
    }

    public void reload()
    {
        if (mag >= magSize)
            return;

        else
        {
            int reloadCount = magSize - mag;

            if (ammo < reloadCount)
            {
                mag += ammo;
                ammo = 0;
            }

            else
            {
                mag += reloadCount;
                ammo -= reloadCount;
            }

            relo = true;
            mayfire = false;
            StartCoroutine("reloadingCooldown");
            return;
        }
    }

    public void equip(PlayerContr player)
    {
        player.currentGun = this;

        transform.SetPositionAndRotation(player.gunSlot.position, player.gunSlot.rotation);
        transform.SetParent(player.gunSlot);

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().isTrigger = true;

        directionOfFire = Camera.main;
        this.player = player;
    }

    public void unequip()
    {
        player.currentGun = null;

        transform.SetParent(null);

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().isTrigger = false;

        directionOfFire = null;
        this.player = null;
    }

    IEnumerator cooldownFire()
    {
        yield return new WaitForSeconds(fireRate);

        if (mag > 0)
            mayfire = true;
    }

    IEnumerator reloadingCooldown()
    {
        yield return new WaitForSeconds(reloColdown);

        relo = false;
        mayfire = true;
    }
}
