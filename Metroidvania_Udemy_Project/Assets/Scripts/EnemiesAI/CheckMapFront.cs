using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class CheckMapFront : Conditional
    {
        [SerializeField] private Transform frontPoint;
        [SerializeField] private float circleRadius = 0.5f;
        [SerializeField] private LayerMask layersMToCheck;

        public override TaskStatus OnUpdate()
        {
            if(Physics2D.OverlapCircle(frontPoint.position, circleRadius, layersMToCheck))
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Failure;

        }
    }
}