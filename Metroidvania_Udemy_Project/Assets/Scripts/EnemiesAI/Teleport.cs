using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UIElements;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class Teleport : Action
    {
        [SerializeField] private bool teleportNearPlayer = true;
        [SerializeField] private UnityEngine.Transform[] teleportPoints;
        [SerializeField] private float teleportTime = 2f;

        private UnityEngine.Transform newTeleportPoint;
        private float bestDistanceToPlayer;

        private bool teleported = false;
        private Animator anim;

        public override void OnStart()
        {
            anim = GetComponent<Animator>();

            teleported = false;

            if (teleportNearPlayer)
            {
                newTeleportPoint = teleportPoints[0];
                bestDistanceToPlayer = Vector3.Distance(teleportPoints[0].position, PlayerController.instance.transform.position);

                foreach(UnityEngine.Transform teleportPoint in teleportPoints)
                {
                    if (Vector3.Distance(teleportPoint.position, PlayerController.instance.transform.position) < bestDistanceToPlayer)
                    {
                        newTeleportPoint = teleportPoint;
                        bestDistanceToPlayer = Vector3.Distance(teleportPoint.position, PlayerController.instance.transform.position);
                    }
                }
            }
            else
                newTeleportPoint = teleportPoints[Random.Range(0, teleportPoints.Length)];

            anim.SetTrigger("Teleport");
            anim.SetBool("Invisible", true);
            StartCoroutine(TeleportDelay());
        }
        private IEnumerator TeleportDelay()
        {
            yield return new WaitForSeconds(teleportTime);
            transform.position = newTeleportPoint.position;
            transform.localScale = new Vector3((PlayerController.instance.transform.position.x - transform.position.x) / Mathf.Abs(PlayerController.instance.transform.position.x - transform.position.x), 1f, 1f);
            anim.SetBool("Invisible", false);
            yield return new WaitForSeconds(0.5f);
            teleported = true;
        }

        public override TaskStatus OnUpdate()
        {
            if (teleported)
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }
    }
}