using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHealth : MonoBehaviour
{
    public int health;
    public GameObject healthDrop;
    public Transform dropPoint;
    void Start()
    {
        //health = 1;
    }

    private void Update()
    {
        if(health <= 0)
        {
            SpawnHealth();
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        
        if(other.gameObject.layer == LayerMask.NameToLayer("Explosive"))
        {
            health -= 10;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            health -= 1;
            Destroy(other.gameObject);
        }
    }

    void SpawnHealth()
    {
        Instantiate(healthDrop, dropPoint.position, dropPoint.rotation);
    }

    
}
