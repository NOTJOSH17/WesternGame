using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelOne : MonoBehaviour
{
    public SpriteRenderer horse;
    public GameObject rideHorse;
    public GameObject player;
    public Animator horseMove;
    public Animator Fader;
    public GameObject fade;
    public GameObject Credit;
    public AudioSource BossMusic;
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player.SetActive(false);
            horse.enabled = false;
            rideHorse.SetActive(true);
            horseMove.Play("Horse");
            fade.SetActive(true);
            Fader.Play("FadeOut");
            BossMusic.Stop();
            StartCoroutine(ExitButtons()); 
        }
    }

    IEnumerator ExitButtons()
    {
        yield return new WaitForSeconds(3.4f);
        Credit.SetActive(true);
    }
}
