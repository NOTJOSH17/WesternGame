using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public AudioSource wind1;
    public AudioSource wind2;
    public AudioSource wind3;
    int randNum;
    public float timer;
    float startTime = 6;
    private void Start() {
        timer = 0;
    }

    private void Update() 
    {
        timer -= 1 * Time.deltaTime;
        if(timer <= 0)
        {
            randNum = Random.Range(1,4);
            timer = startTime;

            if(randNum == 1)
            {
                playWind1();
            }
            if(randNum == 2)
            {
                playWind2();
            }
            if(randNum == 3)
            {
                playWind3();
            }
        }  
    }
    void playWind1()
    {
        wind1.Play();
    }
    void playWind2()
    {
        wind2.Play();
    }
    void playWind3()
    {
        wind3.Play();
    }


}
