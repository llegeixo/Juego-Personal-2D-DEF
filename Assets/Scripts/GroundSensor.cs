using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerController controller;
    public bool isGrounded;
    SoundManager soundManager;
    SFXManager sfxManager;


    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponentInParent<PlayerController>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
            controller.anim.SetBool("IsJumping", false);
        }
        else if (other.gameObject.layer == 6)
        {
            sfxManager.EnemyDeath();

            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.Die();
        }
        
        if(other.gameObject.layer == 7)
        {
            sfxManager.CharacterDeath();
            soundManager.StopBGM();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }
}
    

