﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpSeePlayer : MonoBehaviour
{ 
    public bool isRight;
    public GameObject player;
    public Transform EyePoint;
    public LayerMask ShootSaver;
    public SharpCntrl SharpShooterCrtl;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowards(player.transform.position);
        RaycastHit2D hit = Physics2D.Raycast(EyePoint.position, transform.TransformDirection(Vector2.right), 6.5f, ~ShootSaver);//, 
        Debug.DrawRay(EyePoint.position, transform.TransformDirection(Vector2.right) * 6.5f, Color.red);
        
        if(hit.collider.tag == "Player")
        {
            SharpShooterCrtl.canShoot = true;
        }
        else
        {
            SharpShooterCrtl.canShoot = false;
            SharpShooterCrtl.timer = SharpShooterCrtl.startTimer;
        }
    }

    private void RotateTowards(Vector2 target)
    {
        //var offset = 90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(isRight == false) 
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle));  
        } 
        if(isRight == true) 
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle));  
        }     
        
    }
}
