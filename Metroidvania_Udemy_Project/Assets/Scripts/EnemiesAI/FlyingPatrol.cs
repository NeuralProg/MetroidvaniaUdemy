using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{ 
    public class FlyingPatrol : Action
    {
        [Header("Patrol Info")]
        [SerializeField] private UnityEngine.Transform targetedPoint;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private bool shouldChasePlayer = false;

        private Rigidbody2D rb;


        public override void OnStart()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public override TaskStatus OnUpdate()
        {
            if (shouldChasePlayer)
                targetedPoint = PlayerController.instance.transform;

            transform.localScale = new Vector3((targetedPoint.position.x - transform.position.x) / Mathf.Abs(targetedPoint.position.x - transform.position.x), 1f, 1f);
            if ((transform.position.x >= targetedPoint.position.x - 0.4f && transform.position.x <= targetedPoint.position.x + 0.4f) && (transform.position.y >= targetedPoint.position.y - 0.4f && transform.position.y <= targetedPoint.position.y + 0.4f))
            {
                rb.velocity = new Vector2(0f, 0f);
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }

        public override void OnFixedUpdate()
        {
            rb.velocity = new Vector2((targetedPoint.position.x - transform.position.x) / Mathf.Abs(targetedPoint.position.x - transform.position.x) * moveSpeed, (targetedPoint.position.y - transform.position.y) / Mathf.Abs(targetedPoint.position.y - transform.position.y) * moveSpeed);
            gameObject.GetComponentInChildren<Animator>().SetBool("Awake", true);
        }

    }
}