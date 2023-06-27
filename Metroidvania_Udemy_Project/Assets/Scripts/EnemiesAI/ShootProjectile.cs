using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{ 
    public class ShootProjectile : Action
    {
        [SerializeField] private int shootDamage = 1;
        [SerializeField] private BulletController bullet;
        [SerializeField] private UnityEngine.Transform shootPoint;
        private Vector2 shootDirection;

        private Rigidbody2D rb;
        private PlayerController player;
        private bool hasShot = false;


        public override void OnStart()
        {
            rb = GetComponent<Rigidbody2D>();
            player = PlayerController.instance;

            shootDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;

            BulletController shoot = Object.Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            shoot.moveDir = shootDirection;
            shoot.damageAmount = shootDamage;
            shoot.shotByPlayer = false;
            shoot.bulletSpeed = 6; 

            hasShot = true;
        }

        public override TaskStatus OnUpdate()
        { 
            if (hasShot)
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }
    }
}