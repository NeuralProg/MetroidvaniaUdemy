using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityTracker : MonoBehaviour
{
    public bool doubleJumpAbility, dashAbility, ballAbility, bombAbility, wallJumpAbility;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            if(PlayerPrefs.GetInt("PlayerDoubleJump") == 1)
                doubleJumpAbility = true;
            if (PlayerPrefs.GetInt("PlayerDash") == 1)
                dashAbility = true;
            if (PlayerPrefs.GetInt("PlayerBall") == 1)
                ballAbility = true;
            if (PlayerPrefs.GetInt("PlayerBomb") == 1)
                bombAbility = true;
            if (PlayerPrefs.GetInt("PlayerWallJump") == 1)
                wallJumpAbility = true;
        }
    }
}
