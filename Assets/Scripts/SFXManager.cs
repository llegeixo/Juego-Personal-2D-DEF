using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip berrypicked;

    private AudioSource source;
    
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void BerryPicked()
    {
        source.PlayOneShot(berrypicked);
    }
}
