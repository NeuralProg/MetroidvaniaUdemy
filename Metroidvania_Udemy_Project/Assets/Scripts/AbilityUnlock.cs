using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUnlock : MonoBehaviour
{
    [SerializeField] private bool unlockDoubleJumpAbility, unlockDashAbility, unlockBallAbility, unlockBombAbility, unlockWallJumpAbility;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerAbilityTracker player = collision.GetComponentInParent<PlayerAbilityTracker>();

            if (unlockDoubleJumpAbility)
                player.doubleJumpAbility = true;
            if (unlockDashAbility)
                player.dashAbility = true;
            if (unlockBallAbility)
                player.ballAbility = true;
            if (unlockBombAbility)
                player.bombAbility = true;
            if (unlockWallJumpAbility)
                player.wallJumpAbility = true;

            Destroy(gameObject);
        }
    }
}
