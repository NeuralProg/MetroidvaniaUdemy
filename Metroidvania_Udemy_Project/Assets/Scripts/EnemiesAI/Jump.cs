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

        private bool hasJumped = false;
        private Rigidbody2D rb;

        public override void OnStart()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(transform.localScale.x * horizontalForce, jumpHeight);
            hasJumped = true;
        }

        public override TaskStatus OnUpdate()
        {

            if (hasJumped)
            {
                gameObject.GetComponentInChildren<Animator>().SetTrigger("Jump");
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;

        }
    }
}