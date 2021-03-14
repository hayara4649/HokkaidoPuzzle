using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    AudioSource source;

    
    private void Start() {
        source = GetComponent<AudioSource>();
    }

    public void TimeOver()
    {
        source.clip = clips[0];
        source.PlayOneShot(source.clip);
    }

    public void Out()
    {
        source.clip = clips[1];
        source.PlayOneShot(source.clip);
    }

    public void Put()
    {
        source.clip = clips[2];
        source.PlayOneShot(source.clip);
    }
}

