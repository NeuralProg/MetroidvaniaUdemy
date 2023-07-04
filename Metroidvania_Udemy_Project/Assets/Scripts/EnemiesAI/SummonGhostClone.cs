using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{ 
    public class SummonGhostClone : Action
    {
        [SerializeField] private GameObject ghostClone;


        private bool summoned = false;


        public override void OnStart()
        {
            summoned = false;

            ghostClone.SetActive(true);

            summoned = true;
        }

        public override TaskStatus OnUpdate()
        { 
            if (summoned)
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }
    }
}