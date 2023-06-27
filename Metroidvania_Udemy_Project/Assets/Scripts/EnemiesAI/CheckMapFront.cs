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
        [SerializeField] private float checkTime = 1f;
        private float checkTimer;
        [SerializeField] private LayerMask layersMToCheck;
        private bool mapFront;

        public override TaskStatus OnUpdate()
        {
            if (Physics2D.OverlapCircle(frontPoint.position, circleRadius, layersMToCheck))
                checkTimer -= Time.deltaTime;
            else
                checkTimer = checkTime;

            if(checkTimer <= 0f)
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Failure;

        }
    }
}