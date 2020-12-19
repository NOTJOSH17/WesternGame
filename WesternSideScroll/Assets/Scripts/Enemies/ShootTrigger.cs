using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrigger : MonoBehaviour
{

    public Bandit[] banditList;
    GameObject[] bandits;
    bool playerInRoom;

    void Update() 
    {
        bandits = GameObject.FindGameObjectsWithTag("Bandit");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {

            for (int i = 0; i < bandits.Length; ++i)
            {
                banditList[i].GetComponent<Bandit>().canShoot = true;
                banditList[i].GetComponent<Bandit>().timer = banditList[i].GetComponent<Bandit>().startTimer;
            
                Destroy(gameObject);
            }  
        }
    }
}
