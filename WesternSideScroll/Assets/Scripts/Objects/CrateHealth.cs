using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHealth : MonoBehaviour
{
    public int health;
    void Start()
    {
        //health = 1;
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Explosive"))
        {
            health -= 10;
        }

        //if (other.collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        //{
            //health -= 1;
        //}
        
    
    }

    
}
