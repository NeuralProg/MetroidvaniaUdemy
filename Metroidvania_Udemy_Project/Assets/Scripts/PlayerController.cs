using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private float moveInput;

    private float moveSpeed = 8;
    private float jumpForce = 20;

    [Header("Checks")]
    public UnityEngine.Transform groundPoint;
    public LayerMask groundMask;
    private bool isOnGround;

    [Header("Shoot")]
    public BulletController shotToFire;
    public UnityEngine.Transform shotPointFront;
    public UnityEngine.Transform shotPointTop;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        // Check Ground
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, groundMask);

        // Jump
        if(Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        // Shoot
        if (Input.GetButtonDown("Shoot") && Input.GetKey(KeyCode.Z) && isOnGround && Mathf.Abs(rb.velocity.x) < 0.1f)
        {
            Instantiate(shotToFire, shotPointTop.position, shotPointTop.rotation).moveDir = new Vector2(0f, 1f);
            anim.SetTrigger("ShotFiredUp");
        }
        else if (Input.GetButtonDown("Shoot"))
        {
            Instantiate(shotToFire, shotPointFront.position, shotPointFront.rotation).moveDir = new Vector2(transform.localScale.x, 0f);
            anim.SetTrigger("ShotFiredFront");
        }


        anim.SetBool("IsGrounded", isOnGround);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }


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
}
