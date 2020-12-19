using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollider : MonoBehaviour
{
    public Bandit Shooter;
    private void Start() 
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Bounce"))
        {
            Shooter.startShooting = false;
            Shooter.timer = Shooter.startTimer;
        }        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Bounce"))
        {
            Shooter.startShooting = true;
        }
    }
}
