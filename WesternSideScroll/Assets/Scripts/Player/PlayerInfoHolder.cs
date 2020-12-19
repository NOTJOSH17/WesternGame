using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoHolder : MonoBehaviour
{

    public GameObject PlayerMover;
    public GameObject PlayerCrouch;
    public bool isCrouching;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = PlayerMover.transform.position;

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
           isCrouching = true;
           PlayerCrouch.transform.parent = transform;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isCrouching = false;
            PlayerCrouch.transform.parent = PlayerMover.transform;
        }

        if(isCrouching == false)
        {
            PlayerMover.SetActive(true);
            PlayerCrouch.SetActive(false);
        }

        if(isCrouching == true)
        {
            PlayerMover.SetActive(false);
            PlayerCrouch.SetActive(true);
        }

    }
}
