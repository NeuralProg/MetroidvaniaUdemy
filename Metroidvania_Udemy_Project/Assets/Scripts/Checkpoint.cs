using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // To control scenes

public class Checkpoint : MonoBehaviour
{
    private bool canSave = true;
    private RespawnController respawnController;

    void Start()
    {
        respawnController = RespawnController.instance;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player" && (UserInput.instance.moveInput.y >= 0.9f && Mathf.Abs(UserInput.instance.moveInput.x) < 0.1f) && canSave)
        {
            canSave = false;

            respawnController.respawnScene = SceneManager.GetActiveScene().buildIndex;
            respawnController.respawnPoint = transform.position;
            respawnController.respawnDirection = transform.localScale.x;

            PlayerPrefs.SetInt("SavedLevel", respawnController.respawnScene); // Save
            PlayerPrefs.SetFloat("SavedPositionX", respawnController.respawnPoint.x);
            PlayerPrefs.SetFloat("SavedPositionY", respawnController.respawnPoint.y);
            PlayerPrefs.SetFloat("SavedPositionZ", respawnController.respawnPoint.z);
            PlayerPrefs.SetFloat("SavedDirection", respawnController.respawnDirection);

            if(PlayerController.instance.gameObject.GetComponent<PlayerAbilityTracker>().doubleJumpAbility)
                PlayerPrefs.SetInt("PlayerDoubleJump", 1);
            else
                PlayerPrefs.SetInt("PlayerDoubleJump", 0);
            if (PlayerController.instance.gameObject.GetComponent<PlayerAbilityTracker>().dashAbility)
                PlayerPrefs.SetInt("PlayerDash", 1);
            else
                PlayerPrefs.SetInt("PlayerDash", 0);
            if (PlayerController.instance.gameObject.GetComponent<PlayerAbilityTracker>().ballAbility)
                PlayerPrefs.SetInt("PlayerBall", 1);
            else
                PlayerPrefs.SetInt("PlayerBall", 0);
            if (PlayerController.instance.gameObject.GetComponent<PlayerAbilityTracker>().bombAbility)
                PlayerPrefs.SetInt("PlayerBomb", 1);
            else
                PlayerPrefs.SetInt("PlayerBomb", 0);
            if (PlayerController.instance.gameObject.GetComponent<PlayerAbilityTracker>().wallJumpAbility)
                PlayerPrefs.SetInt("PlayerWallJump", 1);
            else
                PlayerPrefs.SetInt("PlayerWallJump", 0);
        }
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        canSave = true;
    }
}
