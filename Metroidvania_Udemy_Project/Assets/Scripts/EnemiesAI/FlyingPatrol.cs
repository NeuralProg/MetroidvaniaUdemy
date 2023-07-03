using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using Pathfinding;
using System.Numerics;
using UnityEngine.UIElements;

namespace BehaviorDesigner.Runtime.Tasks
{ 
    public class FlyingPatrol : Action
    {
        [SerializeField] private SpriteRenderer sr;

        [Header("Target Info")]
        [SerializeField] private UnityEngine.Transform[] targetedPoints;
        private UnityEngine.Transform targetedPoint;
        [SerializeField] private bool shouldChooseRandomly = false;
        private int currentTargetIndex = 0;
        [SerializeField] private bool shouldChasePlayer = false;

        [Header("Patrol Info")]
        [SerializeField] private float speed = 300f;
        [SerializeField] private bool finishOnHit = false;
        private bool finished = false;
        [SerializeField] private bool finishOnDuration = false;
        [SerializeField] private float finishOnDurationTime = 0f;
        private float finishOnDurationTimer;

        private float nextWaypointDistance = 3f;
        private Path path;
        private int currentWaypoint = 0;

        private float updateDelay = 0.5f;
        private float updateTimer;

        private Rigidbody2D rb;
        private Seeker seeker;
        private PlayerController player;

        #region Basics

        public override void OnStart()          
        {
            rb = GetComponent<Rigidbody2D>();
            seeker = GetComponent<Seeker>();
            player = PlayerController.instance;

            if (finishOnDuration)
                finishOnDurationTimer = finishOnDurationTime;

                if (shouldChasePlayer)
            {
                targetedPoint = player.gameObject.transform;
            }
            else
            {
                FindNewTargetPoint();
            }

            updateTimer = updateDelay;
            UpdatePath();
        }

        public override TaskStatus OnUpdate()
        {
            updateTimer -= Time.deltaTime;
            bool shouldUpdate = (finishOnHit && shouldChasePlayer) || (!finishOnHit);
            if (updateTimer <= 0 && shouldUpdate)
            {
                UpdatePath();
                updateTimer = updateDelay;
            }

            if (sr != null)
            {
                if (rb.velocity.x > 0.1f)                           // Turn
                    sr.transform.localScale = UnityEngine.Vector3.one;
                else if (rb.velocity.x < -0.1f)
                    sr.transform.localScale = new UnityEngine.Vector3(-1f, 1f, 1f);
            }

            if (shouldChasePlayer)
                targetedPoint = player.gameObject.transform;

            if (finishOnDuration)
                finishOnDurationTimer -= Time.deltaTime;
                if (finishOnDurationTimer < 0f)
                    finished = true;

            if (finished)
            {
                finished = false;
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }

        public override void OnFixedUpdate()
        {
            if (path == null)
                return;

            if (currentWaypoint >= path.vectorPath.Count) // If we are above the number of waypoints of the path
            {
                if (finishOnHit)
                    finished = true;

                if (!shouldChasePlayer)
                    FindNewTargetPoint();

                currentWaypoint = 0;
            }

            UnityEngine.Vector2 direction = ((UnityEngine.Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            UnityEngine.Vector2 force = direction * (speed * rb.mass) * Time.deltaTime;

            rb.AddForce(force);

            float distance = UnityEngine.Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
            if (distance <= nextWaypointDistance)
                currentWaypoint++;
        }

        #endregion

        #region Extra Functions

        private void UpdatePath()
        {
            if(seeker.IsDone()) // Check if the seeker isn't currently making a path
                seeker.StartPath(rb.position, targetedPoint.position, OnPathComplete);
        }

        private void OnPathComplete(Path p)
        {
            if (!p.error) // after calculating the path, make the enemy use it
            {
                path = p;
                currentWaypoint = 0;
            }
        }

        private void FindNewTargetPoint()
        {
            if (shouldChooseRandomly)
            {
                Transform newTargetedPoint = targetedPoints[Random.Range(0, targetedPoints.Length)]; // Random int from 0 to (tagretedPoints-1)

                if (newTargetedPoint != targetedPoint)
                    targetedPoint = newTargetedPoint;
                else
                    FindNewTargetPoint();

                float distance = UnityEngine.Vector2.Distance(rb.position, targetedPoint.position);
                if (distance <= nextWaypointDistance)
                    FindNewTargetPoint();
            }
            else
            {
                if (currentTargetIndex >= targetedPoints.Length-1)
                    currentTargetIndex = 0;
                else
                    currentTargetIndex += 1;

                targetedPoint = targetedPoints[currentTargetIndex];
            }
        }

        #endregion

    }
}