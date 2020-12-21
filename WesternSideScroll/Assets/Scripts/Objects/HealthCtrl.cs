using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCtrl : MonoBehaviour
{
private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            
            if(other.GetComponent<PlayerCntrl>().health >= other.GetComponent<PlayerCntrl>().totalHealth)
            {
                return;  
            }

            if(other.GetComponent<PlayerCntrl>().health <= other.GetComponent<PlayerCntrl>().totalHealth)
            {
                other.GetComponent<PlayerCntrl>().health += 5;
                if(other.GetComponent<PlayerCntrl>().health >= other.GetComponent<PlayerCntrl>().totalHealth)
                {
                    other.GetComponent<PlayerCntrl>().health = other.GetComponent<PlayerCntrl>().totalHealth;
                }
                Destroy(gameObject);
            }
        }
    }
}
