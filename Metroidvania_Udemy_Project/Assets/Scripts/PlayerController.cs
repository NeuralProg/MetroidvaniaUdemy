using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("References")]
    private Rigidbody2D rb;
    private Animator anim;
    private float moveInput;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator animStand;
    [SerializeField] private Animator animBall;

    // Movements vars
    private bool canMove = true;
    private float moveSpeed = 8;
    private float jumpForce = 20;
    private bool canDoubleJump;
    private bool jumping = false;
    private bool willLand = false;
    private float dashSpeed = 25;
    private float dashTime = 0.2f;
    private float dashCooldown = 0.2f;
    private float dashCounter;
    private bool dashing = false;
    private bool dashReset;
    private bool canDash;

    [Header("CollisionCheck")]
    public UnityEngine.Transform groundPoint;
    public UnityEngine.Transform aboveCheck;
    public LayerMask groundMask;
    public GameObject landEffect;
    private bool isOnGround;

    [Header("Shoot")]
    public BulletController shotToFire;
    public UnityEngine.Transform shotPointFront;
    public UnityEngine.Transform shotPointTop;

    [Header("DashTrailEffect")]
    public SpriteRenderer dashAfterImage;
    public Color afterImageColor;
    private float afterImageLifeTime = 0.1f;
    private float timeBetweenAfterImages = (1/30);
    private float afterImageCounter;

    [Header("State")]
    [SerializeField] private GameObject standing;
    [SerializeField] private GameObject ball;
    private float waitToBall = 1f, ballCounter;
    #endregion


    #region Default Functions

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (standing.activeSelf)
            anim = animStand;
        else if (ball.activeSelf)
            anim = animBall;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (canMove)
        {
            Move();  // MOVE left to right and FLIP character
            Jump();  // Check GROUND and JUMP
            Shoot(); // SHOOT
            Dash();  // DASH
            CheckState();
        }
        else
        {
            jumping = false;
            dashing = false;
            dashCounter = 0;
        }

        if (standing.activeSelf)
            anim = animStand;
        else if (ball.activeSelf)
            anim = animBall;

        // Check Ground
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, groundMask);

        if (isOnGround)
        {
            canDoubleJump = true;
            dashReset = true;
        }

        if(rb.velocity.y < -(jumpForce+1))    // Check if the player will spawn particles at landing
        {
            willLand = true;
        }
        if(isOnGround && willLand)
        {
            willLand = false;
            Instantiate(landEffect, groundPoint.transform.position, Quaternion.identity);
        }

        if(Mathf.Abs(rb.velocity.y) > 30)
        {
            rb.velocity = new Vector2(rb.velocity.x, (rb.velocity.y / Mathf.Abs(rb.velocity.y)) * 30);
        }

        anim.SetBool("IsGrounded", isOnGround);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    #endregion


    #region Movements

    private void Move()
    {
        if (canMove)
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
    }

    private void Jump()
    {
        if (!dashing)
        {
            // Jump
            if (UserInput.instance.controls.Jumping.Jump.WasPressedThisFrame() && isOnGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumping = true;
            }
            else if (UserInput.instance.controls.Jumping.Jump.WasPressedThisFrame() && !isOnGround && canDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.SetTrigger("DoubleJump");
                canDoubleJump = false;
                jumping = true;
            }

            if (rb.velocity.y < 0f)   // Check if player is falling
            {
                jumping = false;
            }

            if (UserInput.instance.controls.Jumping.Jump.WasReleasedThisFrame() && jumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce / 4);
                jumping = false;
            }
        }
    }

    private void Shoot()
    {
        if (!dashing && !ball.activeSelf)
        {
            // Shoot
            if (UserInput.instance.controls.Shooting.Shoot.WasPressedThisFrame() && UserInput.instance.moveInput.y > 0 && isOnGround && Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                Instantiate(shotToFire, shotPointTop.position, shotPointTop.rotation).moveDir = new Vector2(0f, 1f);
                anim.SetTrigger("ShotFiredUp");
            }
            else if (UserInput.instance.controls.Shooting.Shoot.WasPressedThisFrame())
            {
                Instantiate(shotToFire, shotPointFront.position, shotPointFront.rotation).moveDir = new Vector2(transform.localScale.x, 0f);
                anim.SetTrigger("ShotFiredFront");
            }
        }
    }

    private void Dash()
    {
        // Dash
        if(UserInput.instance.controls.Dashing.Dash.WasPressedThisFrame() && canDash && standing.activeSelf)
        {
            dashCounter = dashTime + dashCooldown;   // Set the dash timer
            dashing = true;
            dashReset = false;
            canDash = false;
            rb.gravityScale = 0f;
            ShowAfterImage();
        }

        if(dashCooldown > 0)
            dashCounter = dashCounter - Time.deltaTime;

        if(dashCounter > dashCooldown)  // If the player is dashing
        {
            rb.velocity = new Vector2(dashSpeed * transform.localScale.x, 0f);

            afterImageCounter -= Time.deltaTime;
            if(afterImageCounter <= 0)
            {
                ShowAfterImage();
            }
        }
        else 
        {
            dashing = false;
            rb.gravityScale = 5f;
        }

        if (dashReset && dashCounter <= 0)
            canDash = true;
        else
            canDash = false;
    }

    #endregion


    #region Functions

    private void ShowAfterImage()
    {
        SpriteRenderer img = Instantiate(dashAfterImage, transform.position, transform.rotation);
        img.sprite = sr.sprite;
        img.transform.localScale = transform.localScale;
        img.color = afterImageColor;

        Destroy(img.gameObject, afterImageLifeTime); // Destroy gameObject after a certain amount of time

        afterImageCounter = timeBetweenAfterImages;
    }

    private void CheckState()
    {
        if (!ball.activeSelf)
        {
            if(UserInput.instance.controls.SwitchingState.Switch.IsPressed() && isOnGround && Mathf.Abs(rb.velocity.x) < 0.1f)     // We check if the player push the direction down
            {
                ballCounter -= Time.deltaTime;

                if(ballCounter <= 0)            // If the player pressed the button for waitToBall duration
                {
                    ball.SetActive(true);
                    standing.SetActive(false);
                    ballCounter = waitToBall;
                }

                anim.SetBool("SwitchingToBall", true);
            }
            else
            {
                ballCounter = waitToBall;
                anim.SetBool("SwitchingToBall", false);
            }
        }
        else
        {
            if (UserInput.instance.controls.SwitchingState.Switch.IsPressed() && isOnGround && Mathf.Abs(rb.velocity.x) < 0.1f && !Physics2D.OverlapBox(aboveCheck.transform.position, new Vector2(0.9f, 1.6f), 0f, groundMask))     // We check if the player push the direction down
            {
                ballCounter -= Time.deltaTime;

                if (ballCounter <= 0)            // If the player pressed the button for waitToBall duration
                {
                    ball.SetActive(false);
                    standing.SetActive(true);
                    ballCounter = waitToBall;
                }

                anim.SetBool("SwitchingToStand", true);
            }
            else
            {
                ballCounter = waitToBall;
                anim.SetBool("SwitchingToStand", false);
            }
        }
    }

    #endregion
}
