using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class Turn : Action
    {
        private bool turned = false;

        public override void OnStart()
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
            turned = true;
        }

        public override TaskStatus OnUpdate()
        {
            if (turned)
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }
    }
}