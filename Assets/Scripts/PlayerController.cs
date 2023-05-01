using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    int playerHealth = 3;
    public float playerSpeed = 6.5f;
    public float jumpForce = 8f;
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody;
    private GroundSensor sensor;
    float horizontal; 
    public Animator anim;
    public Berry berry;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        anim = GetComponent<Animator>();
        berry = GameObject.Find("Berry").GetComponent<Berry>();
    }

    // Update is called once per frame
    void Update()
    {
       horizontal = Input.GetAxis("Horizontal");

       if(horizontal < 0)
       {
        spriteRenderer.flipX = true;
        anim.SetBool("IsRunning", true);
        anim.SetBool("IsJumping", false);
       }

       else if(horizontal > 0)
       {
        spriteRenderer.flipX = false;
        anim.SetBool("IsRunning", true);
        anim.SetBool("IsJumping", false);
       }
       else
       {
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsJumping", false);
       }
        

       if(Input.GetButtonDown("Jump") && sensor.isGrounded)
       {
        rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        anim.SetBool("IsJumping", true);
        anim.SetBool("IsRunning", false);
       }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CollisionBerry")
        {
            Berry berry = collision.gameObject.GetComponent<Berry>(); 
            berry.Pick();
        
        }
    }
        
    void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);
    }
}
