using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainDoor : MonoBehaviour
{
    public GameObject player;
    public PlayerCntrl PlayerController;
    public GameObject eKey;
    public TrainCtlr trainController;
    public SpriteRenderer door;
    public Color clr;
    public int pressCounter;
    bool canOpen;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerMain");
        PlayerController = player.GetComponent<PlayerCntrl>();
        door = GetComponent<SpriteRenderer>();
        
    }

    void OnTriggerStay2D(Collider2D other)  
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            canOpen = true;
            eKey.SetActive(true); 
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            canOpen = false;
            eKey.SetActive(false);
        }
    }
    void Update() 
    {
        door.color = clr;
        if(canOpen == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                clr.a = 0.5f;
                trainController.InRoom = true;
                door.sortingLayerName = "ForeGround";
                pressCounter += 1;
                
            }
        }  

        else if(canOpen == false)
        {
            return;
        }  

        if(pressCounter >= 2)
        {
            trainController.InRoom = false;
            door.sortingLayerName = "Objects";
            clr.a = 1f;
            pressCounter = 0;
        }
    }
}
