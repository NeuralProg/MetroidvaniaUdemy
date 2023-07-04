using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UIElements;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class SetPosition : Action
    {
        [SerializeField] private UnityEngine.Transform teleportPoint;
        private bool posSet = false;

        public override void OnStart()
        {
            posSet = false;

            transform.position = teleportPoint.position;

            posSet = true;
        }

        public override TaskStatus OnUpdate()
        {
            if (posSet)
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }
    }
}