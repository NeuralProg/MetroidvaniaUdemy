using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class CheckDistanceToObject : Conditional
    {
        [SerializeField] private float distanceBelow = 3f;
        [SerializeField] private GameObject objectToCheck;

        public override TaskStatus OnUpdate()
        {
            if (Vector3.Distance(transform.position, objectToCheck.transform.position) < distanceBelow)
                return TaskStatus.Success;
            else
                return TaskStatus.Failure;
        }
    }
}