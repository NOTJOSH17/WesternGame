using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownPlat : MonoBehaviour
{
    public GameObject Platform;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Platform.SetActive(true);  
        }
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Platform.SetActive(false);
        }
    }
}
