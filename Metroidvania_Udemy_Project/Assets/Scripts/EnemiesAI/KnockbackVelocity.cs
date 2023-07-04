using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class KnockbackVelocity : Action
    {
        [SerializeField] private bool isBoss = true;
        [SerializeField] private float newKBVelocity;
        private bool done = false;

        public override void OnStart()
        {
            if (isBoss)
                GetComponent<Boss>().knockbackVelocity = newKBVelocity;
            else
                GetComponent<Enemy>().knockbackVelocity = newKBVelocity;

            done = true;
        }

        public override TaskStatus OnUpdate()
        {
            if (done)
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }
    }
}