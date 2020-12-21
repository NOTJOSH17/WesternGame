using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClipCtrl : MonoBehaviour
{
    public PlayerCntrl playerCtrlScpt;
    public GameObject Clip1;
    public GameObject Clip2;
    public GameObject Clip3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCtrlScpt.clipCount >= 1)
        {
            Clip1.SetActive(true);
        }
        else if(playerCtrlScpt.clipCount <= 1)
        {
            Clip1.SetActive(false);
        }
        if(playerCtrlScpt.clipCount >= 2)
        {
            Clip2.SetActive(true);
        }
        else if(playerCtrlScpt.clipCount <= 2)
        {
            Clip2.SetActive(false);
        }
        if(playerCtrlScpt.clipCount >= 3)
        {
            Clip3.SetActive(true);
        }
        else if(playerCtrlScpt.clipCount <= 3)
        {
            Clip3.SetActive(false);
        }

    }
}
