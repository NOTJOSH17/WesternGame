using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFacePlayer : MonoBehaviour
{
    public GameObject player;
    public Transform Gun;
    public bool isRight;
    void Start() 
    {
        isRight = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        RotateTowards(player.transform.position);
    }

    private void RotateTowards(Vector2 target)
    {
        //var offset = 90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float rightAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float leftAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(isRight == false) 
        {
            transform.rotation = Quaternion.Euler(new Vector3(180,0,-1 *rightAngle));  
        } 
        if(isRight == true) 
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,0,1 *leftAngle));  
        }     
        
    }
}
