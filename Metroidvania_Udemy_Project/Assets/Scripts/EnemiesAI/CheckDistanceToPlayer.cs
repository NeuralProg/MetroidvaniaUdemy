using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class CheckDistanceToPlayer : Conditional
    {
        [SerializeField] private float rangeToStartChase;
        private Transform player;

        public override void OnStart()
        {
            player = PlayerController.instance.transform;
        }

        public override TaskStatus OnUpdate()
        {
            if(Vector3.Distance(transform.position, player.position) < rangeToStartChase && player.gameObject.activeSelf)
                return TaskStatus.Success;
            else
                return TaskStatus.Failure;
        }
    }
}