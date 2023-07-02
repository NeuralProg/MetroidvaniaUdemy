using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class CheckIfIsNotKnockbacked : Conditional
    {
        public override TaskStatus OnUpdate()
        {
            if(!GetComponent<Enemy>().isKnockbacked)
                return TaskStatus.Success;
            else
                return TaskStatus.Failure;
        }
    }
}