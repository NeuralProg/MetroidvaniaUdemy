using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class Jump : Action
    {
        [SerializeField] private float horizontalForce = 5f;
        [SerializeField] private float jumpHeight = 10f;
        [SerializeField] private float jumpTime = 2f;
        private float jumpTimer;

        private bool hasJumped = false;
        private Rigidbody2D rb;

        public override void OnStart()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(transform.localScale.x * horizontalForce, jumpHeight);
            gameObject.GetComponentInChildren<Animator>().SetTrigger("Jump");

            jumpTimer = jumpTime;
        }

        public override TaskStatus OnUpdate()
        {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0f)
                hasJumped = true;
            else
                hasJumped = false;

            if (hasJumped)
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;

        }
    }
}