using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHealth : MonoBehaviour
{
    public int health;
    public GameObject healthDrop;
    public Transform dropPoint;
    public Collider2D boxCollider;
    public LayerMask explosiveLayer;
    public LayerMask bulletLayer;
    GameObject bullet;
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

        if(TntTouch())
        {
            health -= 1;
        }

        if(BulletHit())
        {
            health -= 1;
        }
        }

    private bool TntTouch()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, explosiveLayer);
        return hit.collider != null;
    }
    private bool BulletHit()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, bulletLayer);
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            bullet = hit.collider.gameObject;
            Destroy(bullet);
        }
        return hit.collider != null;
    }

    void SpawnHealth()
    {
        Instantiate(healthDrop, dropPoint.position, dropPoint.rotation);
    }

    
}
