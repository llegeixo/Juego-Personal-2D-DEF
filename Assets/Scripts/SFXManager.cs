using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip berrypicked;
    public AudioClip characterdeath;
    public AudioClip enemydeath;

    private AudioSource source;
    
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void BerryPicked()
    {
        source.PlayOneShot(berrypicked);
    }

    public void CharacterDeath()
    {
        source.PlayOneShot(characterdeath);
    }

    public void EnemyDeath()
    {
        source.PlayOneShot(enemydeath);
    }
}
