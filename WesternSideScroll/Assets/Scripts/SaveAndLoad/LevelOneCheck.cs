using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneCheck : MonoBehaviour
{
    public Transform checkpoint;
    public GameObject Player;
    public bool checkpointSet;
    public GameObject FlagBase;
    public GameObject Flag;
    public GameObject Flap;
    public Animator animator;
    public bool CheckBool;
    GameObject SaveHolder;
    public SaveData saves;

    void Start() 
    {

    }
    void Update()
    {
        if(Player.transform.position.x >= checkpoint.position.x)
        {
            FlagBase.SetActive(false);
            Flag.SetActive(true);
            CheckBool = true;
            checkpointSet = true;
            CheckSaveSystem.SaveCheckpoint(this);
        }

        if(CheckBool == true)
        {
            StartCoroutine(AnimatorFlagStart());
        }

    }

    IEnumerator AnimatorFlagStart()
    {
        yield return new WaitForSeconds(.1f);
        Flap.SetActive(true);

    }
}
