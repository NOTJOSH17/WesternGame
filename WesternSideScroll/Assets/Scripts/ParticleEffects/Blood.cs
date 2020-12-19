using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public ParticleSystem bloodEffect;
    void Start()
    {
        bloodEffect.Play();
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1.7f);
        Destroy(gameObject);
    }

}
