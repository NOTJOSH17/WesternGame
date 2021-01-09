using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockaidHealth : MonoBehaviour
{
    public int health;
    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnColliderEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            health -= 1;
            
        }
    }
}
