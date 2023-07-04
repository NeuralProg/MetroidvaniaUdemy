using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class SetCinematicMode : Action
    {
        [SerializeField] private float cinematicTime = 5f;
        private bool done = false;

        public override void OnStart()
        {
            UIController.instance.Cinematic(cinematicTime);
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