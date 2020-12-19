using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTCnrtl : MonoBehaviour
{
    
    public GameObject explosionDamage;
    public Transform explosionPoint;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            
            Explosion();
        }
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Explosive"))
        {
            
            Explosion();
        }

    }

    public void Explosion()
    {
        Instantiate(explosionDamage, explosionPoint.position, explosionPoint.rotation);
        Destroy(gameObject);
    }
}
