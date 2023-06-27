using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{ 
    public class Patrol : Action
    {
        [Header("Patrol Info")]
        [SerializeField] private UnityEngine.Transform targetedPoint;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private bool shouldChasePlayer = false;

        [Header("Jump Info")]
        [SerializeField] private float jumpHeight = 10f;
        [SerializeField] private Transform frontPoint;
        [SerializeField] private float circleRadius = 0.5f;
        [SerializeField] private LayerMask layersToCheckForJump;
        private float jumpCooldown = 1f;
        private float jumpTimer = 0f;

        private Rigidbody2D rb;

        public override void OnStart()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public override TaskStatus OnUpdate()
        {
            if (shouldChasePlayer)
                targetedPoint = PlayerController.instance.transform;

            if(jumpTimer > 0)
            {
                jumpTimer -= Time.deltaTime;
            }

            transform.localScale = new Vector3((targetedPoint.position.x - transform.position.x) / Mathf.Abs(targetedPoint.position.x - transform.position.x), 1f, 1f);
            if (transform.position.x >= targetedPoint.position.x - 0.2f && transform.position.x <= targetedPoint.position.x + 0.2f)
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
                gameObject.GetComponentInChildren<Animator>().SetFloat("Speed", Mathf.Abs(rb.velocity.x));
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }

        public override void OnFixedUpdate()
        {
            rb.velocity = new Vector2((targetedPoint.position.x - transform.position.x) / Mathf.Abs(targetedPoint.position.x - transform.position.x) * moveSpeed, rb.velocity.y);
            gameObject.GetComponentInChildren<Animator>().SetFloat("Speed", Mathf.Abs(rb.velocity.x));

            if (Physics2D.OverlapCircle(frontPoint.position, circleRadius, layersToCheckForJump) && jumpTimer <= 0)
            {
                rb.velocity = new Vector2(transform.localScale.x * moveSpeed, jumpHeight);
                gameObject.GetComponentInChildren<Animator>().SetTrigger("Jump");
                jumpTimer = jumpCooldown;
            }
        }

    }
}