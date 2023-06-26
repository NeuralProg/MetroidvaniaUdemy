using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{ 
    public class Patroll : Action
    {
        [SerializeField] private UnityEngine.Transform targetedPoint;
        [SerializeField] private float moveSpeed = 5f;

        private Rigidbody2D rb;

        public override void OnStart()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public override TaskStatus OnUpdate()
        {

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
        }

    }
}