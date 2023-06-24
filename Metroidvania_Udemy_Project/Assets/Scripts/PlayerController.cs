using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D theRB;
    private Animator anim;

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
        theRB = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move sideways
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

        // Flip
        if(theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(theRB.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        

        // Check Ground
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, groundMask);

        // Jump
        if(Input.GetButtonDown("Jump") && isOnGround)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }


        // Shoot
        if (Input.GetButtonDown("Shoot") && Input.GetKey(KeyCode.Z) && isOnGround && Mathf.Abs(theRB.velocity.x) < 0.1f)
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
        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
    }
}
