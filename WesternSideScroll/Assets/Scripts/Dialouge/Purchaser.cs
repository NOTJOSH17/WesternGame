using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Purchaser : MonoBehaviour
{
    
    public Text coin;
    public int coinCount;

    public Dialogue dialogue;

    public bool health;
    public bool ammo;

    public GameObject textManager;
    
    void Start() 
    {



    }

    void Update()
    {
        coin.text = "$" + coinCount;
    }

    public void Health()
    {
        health = true;
    }

    public void Ammo()
    {
        ammo = true;
    }

    public void Yes()
    {
        if(health == true)
        {
            coinCount -= 10;
            
            FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
            StopAllCoroutines();
            StartCoroutine(Convo());
        }

        if(ammo == true)
        {
            coinCount -= 25;

            FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
            StopAllCoroutines();
            StartCoroutine(Convo());
        }
    }

    public void No()
    {
        FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
        StopAllCoroutines();
        StartCoroutine(Convo());
    }

    IEnumerator Convo()
    {
        yield return new WaitForSeconds(.5f);
        FindObjectOfType<dialogueManager>().DisplayNextSentence();
    }
}
