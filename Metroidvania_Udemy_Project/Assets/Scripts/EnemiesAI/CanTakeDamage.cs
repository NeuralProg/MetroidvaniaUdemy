using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class CanTakeDamage : Action
    {
        [SerializeField] private bool takeDamage = true;
        private bool done = false;

        public override void OnStart()
        {
            GetComponent<Boss>().canTakeDamage = takeDamage;
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