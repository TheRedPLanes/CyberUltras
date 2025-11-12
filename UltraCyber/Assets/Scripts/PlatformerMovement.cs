using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    public float doubleJump = 0f;
    public float sprintSpeed = 10f;
    public float maxStamina = 100f;
    public float staminaDrainRate = 10f; // Stamina drained per second while sprinting
    public float staminaRechargeRate = 5f; // Stamina recharged per second while not sprinting

    private float currentSpeed;
    private float currentStamina;
    bool grounded = false;
    bool aired = false;
    //where do we want to play the sound
    AudioSource audioSource;
    AudioSource djAudioSource;
    //what sound do we want to play when we jump
    public AudioClip jumpSound;
    public AudioClip airJumpSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = Camera.main.GetComponent<AudioSource>();
        djAudioSource = Camera.main.GetComponent<AudioSource>();
        
        currentSpeed = moveSpeed;
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            currentSpeed = sprintSpeed;
            currentStamina -= staminaDrainRate * Time.deltaTime;
            currentStamina = Mathf.Max(0, currentStamina); // Ensure stamina doesn't go below 0
        }
        else
        {
            currentSpeed = moveSpeed;
            currentStamina += staminaRechargeRate * Time.deltaTime;
            currentStamina = Mathf.Min(maxStamina, currentStamina); // Ensure stamina doesn't exceed max
        }
        if (currentStamina <= 0)
        {
            currentSpeed = moveSpeed;
        }
        //when we press left or right, move the char left/right
        float moveX = Input.GetAxis("Horizontal");
        //maintain the integrity of our Y velocity
        Vector3 velocity = rb.velocity;
        velocity.x = moveX * currentSpeed;
        rb.velocity = velocity;
        //if you press space AND you're on the ground, jump the char
        if (Input.GetButtonDown("Jump") && grounded)
        {
            //play my jump sound
            if (audioSource != null && jumpSound != null)
            {
                //play the jump sound
                audioSource.PlayOneShot(jumpSound);
            }
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
        }
        if (Input.GetButtonDown("Jump") && aired && doubleJump > 0)
        {
            //play my jump sound
            if (djAudioSource != null && airJumpSound != null)
            {
                //play the jump sound
                djAudioSource.PlayOneShot(airJumpSound);
            }
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            doubleJump = doubleJump - 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            doubleJump = 1f;
            aired = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = false;
            aired = true;
        }
    }
    public void UpgradeSpeed()
    {
        moveSpeed += 0.1f;
    }
}
