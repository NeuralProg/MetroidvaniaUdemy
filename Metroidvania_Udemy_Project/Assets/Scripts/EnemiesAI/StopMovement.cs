using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class StopMovement : Action
    {
        private bool stoped = false;

        public override void OnStart()
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            foreach(AnimatorControllerParameter param in gameObject.GetComponentInChildren<Animator>().parameters)
            {
                if(param.name == "Speed")
                    gameObject.GetComponentInChildren<Animator>().SetFloat("Speed", 0f);
            }
            stoped = true;
        }

        public override TaskStatus OnUpdate()
        {
            if (stoped)
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }
    }
}