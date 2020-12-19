using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public AudioSource Boom;
    // Start is called before the first frame update
    void Start()
    {
        Boom.Play();
        explosionParticle.Play();
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }

}
