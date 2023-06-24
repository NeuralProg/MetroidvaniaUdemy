using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    #region Variables
    // Components vars
    private Rigidbody2D rb;
    private Animator anim;
    private float moveInput;

    // Movements vars
    private float moveSpeed = 8;
    private float jumpForce = 20;
    private bool canDoubleJump;
    private bool jumping = false;
    private bool falling = false;
    private bool willLand = false;

    [Header("GroundCheck")]
    public UnityEngine.Transform groundPoint;
    public LayerMask groundMask;
    public GameObject landEffect;
    private bool isOnGround;

    [Header("Shoot")]
    public BulletController shotToFire;
    public UnityEngine.Transform shotPointFront;
    public UnityEngine.Transform shotPointTop;
    #endregion


    #region Default Functions

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Move();  // MOVE left to right and FLIP character
        Jump();  // Check GROUND and JUMP
        Shoot(); // SHOOT

        if (isOnGround)
        {
            canDoubleJump = true;
        }

        if (rb.velocity.y < 0f)   // Check if player is falling
        {
            jumping = false;
        }

        if(rb.velocity.y < -(jumpForce-1))    // Check if the player will spawn particles at landing
        {
            willLand = true;
        }
        if(isOnGround && willLand)
        {
            willLand = false;
            Instantiate(landEffect, groundPoint.transform.position, Quaternion.identity);
        }

        anim.SetBool("IsGrounded", isOnGround);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    #endregion


    #region Movements

    private void Move()
    {
        // Take x value of move input
        moveInput = UserInput.instance.moveInput.x;

        // Move sideways
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }

    }

    private void Jump()
    {
        // Check Ground
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, groundMask);

        // Jump
        if(UserInput.instance.controls.Jumping.Jump.WasPressedThisFrame() && isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumping = true;
        }
        else if(UserInput.instance.controls.Jumping.Jump.WasPressedThisFrame() && !isOnGround && canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("DoubleJump");
            canDoubleJump = false;
            jumping = true;
        }
        if(UserInput.instance.controls.Jumping.Jump.WasReleasedThisFrame() && jumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce/4);
            jumping = false;
        }
    }

    private void Shoot()
    {
        // Shoot
        if(UserInput.instance.controls.Shooting.Shoot.WasPressedThisFrame() && UserInput.instance.moveInput.y > 0 && isOnGround && Mathf.Abs(rb.velocity.x) < 0.1f)
        {
            Instantiate(shotToFire, shotPointTop.position, shotPointTop.rotation).moveDir = new Vector2(0f, 1f);
            anim.SetTrigger("ShotFiredUp");
        }
        else if(UserInput.instance.controls.Shooting.Shoot.WasPressedThisFrame())
        {
            Instantiate(shotToFire, shotPointFront.position, shotPointFront.rotation).moveDir = new Vector2(transform.localScale.x, 0f);
            anim.SetTrigger("ShotFiredFront");
        }
    }

    #endregion
}
