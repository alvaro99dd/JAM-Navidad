using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    CharacterController cC;
    PlayerController pC;
    public TravelToStaff toStaff;

    Vector3 playerVelocity;
    public float staffJumpHeight;
    public float staffRollHeight;
    public float jumpHeight;
    public float rollJumpHeight;
    public float hangedHeight;
    float height;
    public float gravityValue;
    bool groundedPlayer;
    public bool airJump = false;

    bool jumpPressed = false;
    public float maxDistance;
    public LayerMask interactableLayers;

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
            pC.aS.PlayOneShot(AudioLibrary.instance.jump);
            if (!pC.rolling) {
                if (CollectableManager.instance.staffJump && transform.Find("StaffHolder").childCount > 0 && !airJump) {
                    pC.anim.SetTrigger("Staff");
                    height = staffJumpHeight;
                } else {
                    pC.anim.SetTrigger("Jump");
                    if (toStaff.hanged) {
                        height = hangedHeight;
                    } else {
                        height = jumpHeight;
                    }
                }
            } else {
                if (CollectableManager.instance.staffJump && transform.Find("StaffHolder").childCount > 0 && !airJump) {
                    pC.anim.SetTrigger("Staff");
                    height = staffRollHeight;
                } else {
                    pC.anim.SetTrigger("Jump");
                    height = rollJumpHeight;
                }
                cC.height = pC.colliderHeight;
                cC.center = new Vector3(0, pC.colliderCenter, 0);
            }

            playerVelocity.y = 0f;
            playerVelocity.y += Mathf.Sqrt(height * -gravityValue);
            jumpPressed = false;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        cC.Move(playerVelocity * Time.deltaTime);
    }

    void OnJump() {
        pC.anim.ResetTrigger("Jump");
        pC.anim.ResetTrigger("Staff");
        Debug.Log("Jump pressed");

        if (toStaff.hanged) {
            toStaff.hanged = false;
            toStaff.StopHanging();
        }

        if (cC.isGrounded) {
            Debug.Log("Can jump");
            if (pC.rollCoroutine != null) {
                StopCoroutine(pC.rollCoroutine);
                Debug.LogWarning("corrutina parada");
            }
            jumpPressed = true;
        } else {
            if (!airJump || toStaff.hanged) {
                jumpPressed = true;
                airJump = true;
            } else {
                Debug.Log("Cant jump in the air");
            }
        }
    }
}