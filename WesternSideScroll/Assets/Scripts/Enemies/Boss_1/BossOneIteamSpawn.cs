using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneIteamSpawn : MonoBehaviour
{
    public Transform barrelSpawn;
    public Transform ammoSpawn;

    public GameObject barrel;
    public GameObject Ammo;

    public float ammoTimer;
    public float maxAmmoTimer;

    public float barrelTimer;
    public float maxBarrelTimer;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D barrelHit = Physics2D.Raycast(barrelSpawn.position, barrelSpawn.TransformDirection(Vector2.down), .5f);//, ~ShootSaver
        Debug.DrawRay(barrelSpawn.position, barrelSpawn.TransformDirection(Vector2.down) * .5f, Color.red);
        
        if(barrelHit.collider.tag != "PickUp")
        {
            barrelTimer -= 1 * Time.deltaTime;
            if(barrelTimer <= 0)
            {
                Instantiate(barrel, barrelSpawn.position, barrelSpawn.rotation);
                barrelTimer = maxBarrelTimer;
            }
        }

        RaycastHit2D ammoHit = Physics2D.Raycast(ammoSpawn.position, ammoSpawn.TransformDirection(Vector2.down), .5f);//, ~ShootSaver
        Debug.DrawRay(ammoSpawn.position, ammoSpawn.TransformDirection(Vector2.down) * .5f, Color.red);
        
        if(ammoHit.collider.tag != "PickUp")
        {
            ammoTimer -= 1 * Time.deltaTime;
            if(ammoTimer <= 0)
            {
                Instantiate(Ammo, ammoSpawn.position, ammoSpawn.rotation);
                ammoTimer = maxAmmoTimer;
            }
        }


    }
}
