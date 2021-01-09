using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTSpawner : MonoBehaviour
{

    public float timer;
    public float maxTimer;
    public float holdTimer;
    public float maxHoldTime;
    public GameObject rollTNT;
    public BossCntrl boss;
    public bool startTimer;
    public bool isHolding;
    public bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
        holdTimer = maxHoldTime;
        startTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer == true)
        {
            timer -= 1 * Time.deltaTime;
        }
        else if(startTimer == false)
        {
            timer = maxTimer;
        }

        if(isHolding == true)
        {
            holdTimer -= 1 * Time.deltaTime;
            boss.shootCounter = 0;
        }

        if(holdTimer <= 0)
        {
            boss.startShooting = true;
            isHolding = false;
            holdTimer = maxHoldTime; 
        }


        if(timer <= 0)
        {
            Spawn();
            startTimer = false;
        }
    }

    public void Spawn()
    {
        Instantiate(rollTNT, this.transform.position, this.transform.rotation);
    }
    
}
