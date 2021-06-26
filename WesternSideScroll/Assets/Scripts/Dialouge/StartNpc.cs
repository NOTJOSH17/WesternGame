using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNpc : MonoBehaviour
{
    public Dialogue dialogue;

    public void Start()
    {
        FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
    }
}
