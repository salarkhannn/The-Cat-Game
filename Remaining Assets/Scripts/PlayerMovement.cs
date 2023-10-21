using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    //initialize float for the player's speed and jump velocity
    public float speed = 10f;
    public float jumpVelocity;

    //initializes layer mask for the ground layer
    public LayerMask groundLayer;

    //references some components from unity
    public Animator anim;
    [SerializeField] private TrailRenderer tr;
    private CircleCollider2D circleCollider;
    private SpriteRenderer sr;

    //initiazle variables used for dashing
    public float dashVelocity = 10f;
    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashingPower = 5f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;

    //initializes variables for coyote time
    private float coyoteTime = 0.5f;
    private float coyoteTimeCounter;

    float x;
    float y;
    //for the animations
    float movementX;
    float movementY;

    private void Start()
    {
        //gets components from unity
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        //play respawn animation
        anim.SetTrigger("Respawn");
    }

    private void Update()
    {
        //check if the player is currently dashing
        if (isDashing)
        {
            //don't allow the player to jump or move if in midst of a dash
            return;
        }
        // used for the animations
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");
        // Input handling
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);

        Run(dir);
        //check if the player is pressing the move button
        if(Input.GetButtonUp("Horizontal"))
        {
            //if not, deccelerate
            Deccelerate(dir);
        }

        //if the player is on the ground, reset the coyote timer
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        } else
        {
            //else subtract Time.deltaTime from coyote Time counter
            coyoteTimeCounter -= Time.deltaTime;
        }

        /*if the coyoteTimeCounter is greater than zero(the player is on the ground)
        and if the player has pressed the jump button, call the jump function*/
        if (coyoteTimeCounter > 0f && Input.GetButtonDown("Jump"))
        {
            Jump(dir);
        }

        if (Input.GetButtonUp("Jump"))
        {
            coyoteTimeCounter = 0f;
        }

        //if canDash is true and the player has pressed dash button, call the dash function
        if (Input.GetButtonDown("Dash") && canDash)
        {
            StartCoroutine(Dash());
        }
        //animate the player
        AnimatePlayer();
    }
    #region Run
    //Run function
    private void Run(Vector2 dir)
    {
        //adds horizontal velocity to the rigidbody (player).
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }
    //Deccelarate function
    private void Deccelerate(Vector2 dir)
    {
        //makes the horizontal velocity zero
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
    #endregion
    #region Jump
    //Jump function
    private void Jump(Vector2 dir)
    {   
        //sets the vertical velocity of the rigidbody to zero
        rb.velocity = new Vector2(rb.velocity.x, 0);
        //adds to the vertical velocity
        rb.velocity += Vector2.up * jumpVelocity;

        //plays the jump sound
        FindObjectOfType<AudioManager>().Play("PlayerJump");
    }
    //IsGrounded Function
    private bool IsGrounded() {
        //return whether the player is touching the ground layer
        bool Touhching = Physics2D.IsTouchingLayers(circleCollider, groundLayer);
        return Touhching;
    }
    #endregion

    #region Dash
    private IEnumerator Dash()
    {
        //when the function is called, set canDash to false, and isDashing to true
        canDash = false;
        isDashing = true;
        //temporarily store the gravity of the rigidbody and set the gravity to zero
        float originalGravity = rb.gravityScale;
        //player is not affected by gravity during a dash
        rb.gravityScale = 0f;
        //if the player is facing right, add dashing velocity
        if (transform.eulerAngles == new Vector3(0, 0, 0))
        {
            rb.velocity = new Vector2(dashVelocity * dashingPower, 0f);
        }
        //if the player is facing left, add dashing velocity in the opposite direction
        else
        {
            rb.velocity = new Vector2(-1 * dashVelocity * dashingPower, 0f);
        }
        //emit a trail when the player dashes
        tr.emitting = true;
        //play the dash sound effect
        FindObjectOfType<AudioManager>().Play("PlayerDash");
        //wait while the player is dashing
        yield return new WaitForSeconds(dashingTime);
        //disable the trail
        tr.emitting = false;
        //restore the original gravity
        rb.gravityScale = originalGravity;
        //wait for a bit before allowing the player to dash again
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    #endregion

    #region runAnimation
    //animate function
    void AnimatePlayer()
    {
        //play the animations, and flip the player bases on the direction they are moving
        if (movementX > 0)
        {
            anim.SetBool("Running", true);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (movementX < 0)
        {
            anim.SetBool("Running", true);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            anim.SetBool("Running", false);
        }

    }
    #endregion

}