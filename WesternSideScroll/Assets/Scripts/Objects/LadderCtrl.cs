using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderCtrl : MonoBehaviour
{
    public GameObject player;
    public PlayerCntrl PlayerController;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerMain");
        PlayerController = player.GetComponent<PlayerCntrl>();
    }

    void OnTriggerStay2D(Collider2D other)  
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerController.Climb();
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerController.ExitClimb();
        }
    }
}

