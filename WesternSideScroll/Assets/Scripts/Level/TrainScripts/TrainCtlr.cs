using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCtlr : MonoBehaviour
{
    public bool InRoom;
    public GameObject Exterior;
    public GameObject Interior;

    public bool canSpawn;

    void Start()
    {

    }

    void Update()
    {
        if(InRoom == true)
        {
            Exterior.SetActive(false);
            Interior.SetActive(true);
        }

        if(InRoom == false)
        {
            Exterior.SetActive(true);
            Interior.SetActive(false);
        }
    }
}
