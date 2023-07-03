using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class CheckIfIsDetected : Conditional
    {
        public override TaskStatus OnUpdate()
        {
            if(GetComponent<Boss>().detected)
                return TaskStatus.Success;
            else
                return TaskStatus.Failure;
        }
    }
}