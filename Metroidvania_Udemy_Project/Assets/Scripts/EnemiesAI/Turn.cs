using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class Turn : Action
    {
        [SerializeField] private bool turnToPlayer = false;
        private bool turned = false;

        public override void OnStart()
        {
            if(!turnToPlayer) 
            { 
                transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
                turned = true;
            }
            else
            {
                float xScale = (PlayerController.instance.transform.position.x - transform.position.x) / Mathf.Abs(PlayerController.instance.transform.position.x - transform.position.x);
                transform.localScale = new Vector3(xScale, 1f, 1f);
                turned = true;
            }
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