using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    CharacterController cC;
    PlayerController pC;

    Vector3 playerVelocity;
    public float staffJumpHeight;
    public float staffRollHeight;
    public float jumpHeight;
    public float rollJumpHeight;
    float height;
    public float gravityValue;
    bool groundedPlayer;
    public bool airJump = false;

    bool jumpPressed = false;
    public float maxDistance;
    public LayerMask interactableLayers;
    public Transform foot;

    private void Awake() {
        cC = GetComponent<CharacterController>();
        pC = GetComponent<PlayerController>();
    }

    private void FixedUpdate() {
        JumpMovement();
    }

    void JumpMovement() {
        groundedPlayer = cC.isGrounded;

        Debug.Log(groundedPlayer);

        if (groundedPlayer) {
            if (airJump) {
                airJump = false;
            }
            playerVelocity.y = 0f;
        }

        if (jumpPressed && (groundedPlayer || airJump)) {
            if (!pC.rolling) {
                if (CollectableManager.instance.staffJump && transform.Find("StaffHolder").childCount > 0 && !airJump) {
                    height = staffJumpHeight;
                } else {
                    height = jumpHeight;
                }
            } else {
                if (CollectableManager.instance.staffJump && transform.Find("StaffHolder").childCount > 0 && !airJump) {
                    height = staffRollHeight;
                } else {
                    height = rollJumpHeight;
                }
            }

            playerVelocity.y = 0f;
            playerVelocity.y += Mathf.Sqrt(height * -gravityValue);
            jumpPressed = false;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        cC.Move(playerVelocity * Time.deltaTime);
    }

    void OnJump() {
        Debug.Log("Jump pressed");

        if (cC.isGrounded) {
            Debug.Log("Can jump");
            if (pC.rollCoroutine != null) {
                StopCoroutine(pC.rollCoroutine);
                Debug.LogWarning("corrutina parada");
            }
            jumpPressed = true;
        } else {
            if (!airJump) {
                jumpPressed = true;
                airJump = true;
            } else {
                Debug.Log("Cant jump in the air");
            }
        }
    }
}