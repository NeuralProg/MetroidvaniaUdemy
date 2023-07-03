using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class CheckCurrentHealth : Conditional
    {
        [SerializeField] private bool bossHealth = true;
        [SerializeField] private bool healthEqual = true;
        [SerializeField] private bool healthUnder = false;
        [SerializeField] private int healthToCheck;

        public override TaskStatus OnUpdate()
        {
            if (bossHealth)
            {
                if (healthEqual)
                {
                    if (GetComponent<Boss>().health == healthToCheck)
                        return TaskStatus.Success;
                    else
                        return TaskStatus.Failure;
                }
                else if (healthUnder)
                {
                    if (GetComponent<Boss>().health < healthToCheck)
                        return TaskStatus.Success;
                    else
                        return TaskStatus.Failure;
                }
                else
                {
                    if (GetComponent<Boss>().health > healthToCheck)
                        return TaskStatus.Success;
                    else
                        return TaskStatus.Failure;
                }
            }
            else
            {
                if (healthEqual)
                {
                    if (GetComponent<Enemy>().health == healthToCheck)
                        return TaskStatus.Success;
                    else
                        return TaskStatus.Failure;
                }
                else if (healthUnder)
                {
                    if (GetComponent<Enemy>().health < healthToCheck)
                        return TaskStatus.Success;
                    else
                        return TaskStatus.Failure;
                }
                else
                {
                    if (GetComponent<Enemy>().health > healthToCheck)
                        return TaskStatus.Success;
                    else
                        return TaskStatus.Failure;
                }
            }
        }
    }
}