using UnityEngine;
using System.Collections;

public class DestroyFinishedParticle : MonoBehaviour
{
    //empty particle system to get filled
    private ParticleSystem thisParticleSystem;

    // Use this for initialization
    void Start()
    {
        thisParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisParticleSystem.isPlaying)
        {
            return;
        }

        //If a particcle System is not playing anymore then destroy it
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        //destory the particle after it's visible
        Destroy(gameObject);
    }
}

