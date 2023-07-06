using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; // Make the player script accesible from nowhere (because there will only be one player in the scenes)

    #region Variables
    [Header("References")]
    [SerializeField] private SpriteRenderer standSr;
    [SerializeField] private SpriteRenderer ballSr;
    [SerializeField] private Animator animStand;
    [SerializeField] private Animator animBall;
    private PlayerAbilityTracker abilities;
    [HideInInspector] public Rigidbody2D rb;
    private Animator anim;
    private float moveInput;

    [Header("Health")]
    public int maxHealth = 5;
    [HideInInspector] public int currentHealth;
    public int maxHeals = 3;
    [HideInInspector] public int currentHeals;
    private float healingTime = 1f, healingTimer;
    private float healingCooldownTime = 0.5f, healingCooldownTimer = 0f;
    private float invincibilityTime = 1.5f;
    [HideInInspector]public float invincibilityTimer;
    private float blinkOnHitTime = 0.075f;
    private float blinkOnHitTimer;

    // Movements vars
    [HideInInspector] public bool canMove = true;
    [HideInInspector] public float moveSpeed = 8;
    private float jumpForce = 20;
    private bool canDoubleJump;
    private bool jumping = false;
    private float coyoteTime = 0.15f;
    private float coyoteTimer;
    private bool willLand = false;
    private float dashSpeed = 25;
    private float dashTime = 0.2f;
    private float dashCooldown = 0.2f;
    private float dashCounter;
    private bool dashing = false;
    private bool dashReset;
    private bool canDash = false;

    [Header("CollisionCheck")]
    [SerializeField] private UnityEngine.Transform groundPoint;
    [SerializeField] private UnityEngine.Transform aboveCheck;
    [SerializeField] private LayerMask aboveCheckColisions;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private GameObject landEffect;
    private bool isOnGround;
    [SerializeField] private UnityEngine.Transform wallPoint;

    [SerializeField] private LayerMask wallMask;
    private bool onWall;
    private bool wallJump = false;
    private float wallSlideSpeed = 10f;
    private float wallJumpDuration = 0.15f;
    private float wasWalledCounter;
    private float wasWalledCooldown = 0.2f;

    [Header("Shoot")]
    [SerializeField] private GameObject shotToFire;
    [SerializeField] private UnityEngine.Transform shotPointFront;
    [SerializeField] private UnityEngine.Transform shotPointTop;
    private float shootCooldown = 0.4f; 
    private float shootCounter;
    private int shootDamage = 1;

    [Header("Knockback")]
    [SerializeField] private UnityEngine.Transform playerCenter;
    private float knockbackVelocity = 10f;
    private float knockbackDuration = 0.2f;
    private bool isKnockbacked = false;

    [Header("DashTrailEffect")]
    [SerializeField] private SpriteRenderer dashAfterImage;
    [SerializeField] private Color afterImageColor;
    private float afterImageLifeTime = 0.1f;
    private float timeBetweenAfterImages = (1/30);
    private float afterImageCounter;

    [Header("State")]
    [SerializeField] private GameObject standing;
    [SerializeField] private GameObject ball;
    private float waitToBall = 1f, ballCounter;

    [Header("Bombs")]
    [SerializeField] private GameObject bombObject;
    [SerializeField] private UnityEngine.Transform bombPointFront;
    [SerializeField] private UnityEngine.Transform bombPointUp;

    [Header("Coins")]
    [HideInInspector] public int coins = 0;
    #endregion


    #region Default Functions

    private void Awake()
    {
        if (instance == null) // Set this script as an instance only if there are no existing instances
        {
            instance = this; // Set this script as an instance
            DontDestroyOnLoad(gameObject); // When this GameObject spawn in a scene, we don't destroy it
        }
        else
        {
            instance.canMove = true;
            Destroy(gameObject); // if there is already a player (an instance of this script), we destroy this gameobject
        }

        rb = GetComponent<Rigidbody2D>();
        abilities = GetComponent<PlayerAbilityTracker>();

        if (standing.activeSelf)
            anim = animStand;
        else if (ball.activeSelf)
            anim = animBall;
    }

    void Start()
    {
        currentHealth = maxHealth;
        currentHeals = maxHeals;
    }

    void Update()
    {
        if (canMove)
        {
            Move();  // MOVE left to right and FLIP character
            Jump();  // Check GROUND and JUMP
            Shoot(); // SHOOT
            Dash();  // DASH
            Wall();
            CheckState();
        }
        else
        {
            jumping = false;
            dashing = false;
            dashCounter = 0;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        
        CheckInvincibility();

        if (standing.activeSelf)
            anim = animStand;
        else if (ball.activeSelf)
            anim = animBall;

        // Check Ground
        if(standing.activeSelf)
            isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.4f, groundMask);
        else if (ball.activeSelf)
            isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.275f, groundMask);

        if (isOnGround) // Update The coyote time
        {
            coyoteTimer = coyoteTime;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
        }
        if (isOnGround || onWall) // Reset abilities cooldown
        {
            canDoubleJump = true;
            dashReset = true;
        }

        rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -30f, 30f));

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
        if(!wallJump && !isKnockbacked)
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        else
            if(wallJump)
                rb.velocity = new Vector2((moveInput * moveSpeed / 2) + transform.localScale.x * jumpForce/2f, jumpForce / 2);
            if (isKnockbacked)
            {
                var lerpedXKnockbackVelocity = Mathf.Lerp(rb.velocity.x, 0, Time.deltaTime * 2);
            rb.velocity = new Vector2(lerpedXKnockbackVelocity, rb.velocity.y);
            }

        // Flip
        if (rb.velocity.x < 0 && !isKnockbacked)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x > 0 && !isKnockbacked)
        {
            transform.localScale = Vector3.one;
        }
    }

    private void Jump()
    {
        if (!dashing)
        {
            if (!onWall && wasWalledCounter <= 0)
            {
                // Jump
                if (UserInput.instance.controls.Jumping.Jump.WasPressedThisFrame() && coyoteTimer >= 0f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    jumping = true;

                    AudioManager.instance.PlayAdjustedSFX(12);
                }
                else if (UserInput.instance.controls.Jumping.Jump.WasPressedThisFrame() && coyoteTimer < 0f && canDoubleJump && abilities.doubleJumpAbility)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    anim.SetTrigger("DoubleJump");

                    AudioManager.instance.PlayAdjustedSFX(9);

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

                if (rb.velocity.y < -(jumpForce + 1))    // Check if the player will spawn particles at landing
                {
                    willLand = true;
                }
                if (isOnGround && willLand)
                {
                    willLand = false;
                    Instantiate(landEffect, groundPoint.transform.position, Quaternion.identity);
                }
            }
            else if(!onWall && UserInput.instance.controls.Jumping.Jump.WasPressedThisFrame() && wasWalledCounter > 0 && abilities.wallJumpAbility && !Physics2D.OverlapBox(wallPoint.position, new Vector2(0.8f, 1.35f), 0f, wallMask))
            {
                // Jump forward
                StartCoroutine(WallJump());
   
            }
            else if (onWall && UserInput.instance.controls.Jumping.Jump.WasPressedThisFrame() && abilities.wallJumpAbility)
            {
                // Jump to opposite
                transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
                StartCoroutine(WallJump());
            }

            if (UserInput.instance.controls.Jumping.Jump.WasReleasedThisFrame() && wallJump)
            {
                wallJump = false;
                rb.velocity = new Vector2(rb.velocity.x / 2, rb.velocity.y / 4);
            }
        }
    }

    private void Shoot()
    {
        if (shootCounter >= 0)
        {
            shootCounter -= Time.deltaTime;
        }

        if (standing.activeSelf && ballCounter >= waitToBall && healingTimer >= healingTime)
        {
            if (!dashing && shootCounter < 0)
            {
                // Shoot
                if (UserInput.instance.controls.Shooting.Shoot.IsPressed() && UserInput.instance.moveInput.y > 0 && isOnGround && Mathf.Abs(rb.velocity.x) < 0.1f)
                {
                    GameObject shoot = Instantiate(shotToFire, shotPointTop.position, shotPointTop.rotation);
                    shoot.GetComponent<BulletController>().moveDir = new Vector2(0f, 1f);
                    shoot.GetComponent<BulletController>().damageAmount = shootDamage;
                    shoot.GetComponent<BulletController>().shotByPlayer = true;
                    anim.SetTrigger("ShotFiredUp");
                    shootCounter = shootCooldown;

                    AudioManager.instance.PlayAdjustedSFX(14);
                }
                else if (UserInput.instance.controls.Shooting.Shoot.IsPressed() && shootCounter < 0)
                {
                    GameObject shoot = Instantiate(shotToFire, shotPointFront.position, shotPointFront.rotation);
                    shoot.GetComponent<BulletController>().moveDir = new Vector2(transform.localScale.x, 0f);
                    shoot.GetComponent<BulletController>().damageAmount = shootDamage;
                    shoot.GetComponent<BulletController>().shotByPlayer = true;
                    anim.SetTrigger("ShotFiredFront");
                    shootCounter = shootCooldown;

                    AudioManager.instance.PlayAdjustedSFX(14);
                }
            }
        }
        else
        {
            if (shootCounter < 0 && ball.activeSelf && UserInput.instance.controls.Shooting.Shoot.IsPressed() && UserInput.instance.moveInput.y > 0 && isOnGround && abilities.bombAbility)
            {
                Instantiate(bombObject, bombPointUp.position, bombPointUp.rotation);
                shootCounter = shootCooldown * 2;

                AudioManager.instance.PlayAdjustedSFX(13);
            }
            else if (shootCounter < 0 &&ball.activeSelf && UserInput.instance.controls.Shooting.Shoot.IsPressed() && abilities.bombAbility)
            {
                Instantiate(bombObject, bombPointFront.position, bombPointFront.rotation);
                shootCounter = shootCooldown * 2;

                AudioManager.instance.PlayAdjustedSFX(13);
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

            AudioManager.instance.PlayAdjustedSFX(7);

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

        if (dashReset && dashCounter <= 0 && abilities.dashAbility)
            canDash = true;
        else
            canDash = false;
    }

    private void Wall()
    {
        if (!isOnGround && abilities.wallJumpAbility && !ball.activeSelf && Physics2D.OverlapBox(wallPoint.position, new Vector2(0.8f, 1.35f), 0f, wallMask))
        {
            if((UserInput.instance.moveInput[0] > 0.9f && transform.localScale.x == 1 || UserInput.instance.moveInput[0] < -0.9f && transform.localScale.x == -1) && !onWall)
                onWall = true;
        }
        else
            onWall = false;

        if(onWall)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
            wasWalledCounter = wasWalledCooldown;
        }
        else if(wasWalledCounter >= 0)
        {
            wasWalledCounter -= Time.deltaTime;
        }
    }

    #endregion


    #region Functions

    public void Knockback(UnityEngine.Transform t)
    {
        var dir = playerCenter.position - t.position;

        rb.velocity = dir.normalized * new Vector2(knockbackVelocity, knockbackVelocity * 2);
        StartCoroutine(StopKnockback());
    }
    private IEnumerator StopKnockback()
    {
        isKnockbacked = true;
        yield return new WaitForSeconds(knockbackDuration);
        isKnockbacked = false;
    }

    private void ShowAfterImage()
    {
        SpriteRenderer img = Instantiate(dashAfterImage, transform.position, transform.rotation);
        img.sprite = standSr.sprite;
        img.transform.localScale = transform.localScale;
        img.color = afterImageColor;

        Destroy(img.gameObject, afterImageLifeTime); // Destroy gameObject after a certain amount of time

        afterImageCounter = timeBetweenAfterImages;
    }

    private void CheckState()
    {
        if (!ball.activeSelf && standing.activeSelf)
        {
            // Switch to ball
            if(UserInput.instance.controls.SwitchingState.Switch.IsPressed() && isOnGround && Mathf.Abs(rb.velocity.x) < 0.1f && abilities.ballAbility)    
            {
                ballCounter -= Time.deltaTime;

                if(ballCounter <= 0)            // If the player pressed the button for waitToBall duration
                {
                    ball.SetActive(true);
                    standing.SetActive(false);
                    ballCounter = waitToBall;

                    AudioManager.instance.PlaySFX(6);
                }

                anim.SetBool("SwitchingToBall", true);
            }
            else
            {
                ballCounter = waitToBall;
                anim.SetBool("SwitchingToBall", false);
            }

            // Heal
            if (healingCooldownTimer > 0)
                healingCooldownTimer -= Time.deltaTime;

            if (UserInput.instance.controls.Healing.Heal.IsPressed() && isOnGround && Mathf.Abs(rb.velocity.x) < 0.1f && currentHealth < maxHealth && currentHeals > 0 && healingCooldownTimer <= 0f) 
            {
                healingTimer -= Time.deltaTime;
                if (healingTimer <= 0)            // If the player pressed the button for healingTime duration
                {
                    HealPlayer(1);
                    currentHeals -= 1;
                    healingTimer = healingTime;
                    healingCooldownTimer = healingCooldownTime;
                }

                anim.SetBool("Healing", true);
            }
            else
            {
                healingTimer = healingTime;
                anim.SetBool("Healing", false);
            }
        }
        else if(ball.activeSelf && !standing.activeSelf)
        {
            if (UserInput.instance.controls.SwitchingState.Switch.IsPressed() && isOnGround && Mathf.Abs(rb.velocity.x) < 0.1f && !Physics2D.OverlapBox(aboveCheck.transform.position, new Vector2(0.85f, 1.6f), 0f, aboveCheckColisions) && abilities.ballAbility)     // We check if the player push the direction down
            {
                ballCounter -= Time.deltaTime;

                if (ballCounter <= 0)            // If the player pressed the button for waitToBall duration
                {
                    ball.SetActive(false);
                    standing.SetActive(true);
                    ballCounter = waitToBall;

                    AudioManager.instance.PlaySFX(10);
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

    private IEnumerator WallJump()
    {
        wallJump = true;
        yield return new WaitForSeconds(wallJumpDuration);
        wallJump = false;
    }

    public void DamagePlayer(int damageTaken)
    {
        if (invincibilityTimer <= 0 && canMove) // Only apply damage when not invincible
        {
            currentHealth -= damageTaken;

            StartCoroutine(RedHitmarker());

            if (currentHealth <= 0)
            {
                AudioManager.instance.PlaySFX(8);

                currentHealth = 0; // To prevent being under 0 HP (because we can't display -2 for example in the lifebar)

                foreach (Image heart in UIController.instance.hearts)
                {
                    heart.sprite = UIController.instance.emptyHeart;
                }

                standSr.color = Color.white;
                ballSr.color = Color.white;

                RespawnController.instance.Respawn();
            }
            else
            {
                invincibilityTimer = invincibilityTime;
                blinkOnHitTimer = blinkOnHitTime;

                AudioManager.instance.PlaySFX(11);
            }
        }
    }

    private IEnumerator RedHitmarker()
    {
        standSr.color = Color.red;
        ballSr.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        standSr.color = Color.white;
        ballSr.color = Color.white;
    }

    private void CheckInvincibility()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
            blinkOnHitTimer -= Time.deltaTime;

            if (blinkOnHitTimer <= 0)
            {
                standSr.enabled = !standSr.enabled;
                ballSr.enabled = !ballSr.enabled;

                blinkOnHitTimer = blinkOnHitTime;
            }

            if (invincibilityTimer <= 0)
            {
                blinkOnHitTimer = 0f;

                standSr.enabled = true;
                ballSr.enabled = true;
            }
        }
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    #endregion
}
