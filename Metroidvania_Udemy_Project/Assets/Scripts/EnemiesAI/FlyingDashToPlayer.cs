using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{ 
    public class FlyingDashToPlayer : Action
    {
        [Header("Dash Info")]
        [SerializeField] private float dashDuration = 1f;
        [SerializeField] private float dashSpeed = 5f;
        private float dashTimer;

        private Rigidbody2D rb;
        private UnityEngine.Transform player;


        public override void OnStart()
        {
            rb = GetComponent<Rigidbody2D>();
            player = PlayerController.instance.transform;

            dashTimer = dashDuration;
        }

        public override TaskStatus OnUpdate()
        {
            dashTimer -= Time.deltaTime;

            transform.localScale = new Vector3((player.position.x - transform.position.x) / Mathf.Abs(player.position.x - transform.position.x), 1f, 1f);
            if (dashTimer <= 0 || ((transform.position.x >= player.position.x - 0.4f && transform.position.x <= player.position.x + 0.4f) && (transform.position.y >= player.position.y - 0.4f && transform.position.y <= player.position.y + 0.4f)))
            {
                rb.velocity = new Vector2(0f, 0f);
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }

        public override void OnFixedUpdate()
        {
            rb.velocity = new Vector2((player.position.x - transform.position.x) / Mathf.Abs(player.position.x - transform.position.x) * dashSpeed, (player.position.y - transform.position.y) / Mathf.Abs(player.position.y - transform.position.y) * dashSpeed);
            gameObject.GetComponentInChildren<Animator>().SetBool("Awake", true);
        }

    }
}