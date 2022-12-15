using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour {
    Controls c;
    CharacterController cC;

    public Transform cam;
    public Transform rollPosition;

    public float speed;
    [Header("Turn to camera")]
    public float turnSmoothTime;
    public float turnSmoothVelocity;
    [Header("Roll")]
    public float rollSpeed;
    public bool rolling;

    public float rollTime;
    public IEnumerator rollCoroutine;
    //Si queremos añadir mas dashes en el aire hay que cambiarlo por un int (contador)
    public bool airRolling;

    private void Awake() {
        c = new Controls();
        c.Enable();
        cC = GetComponent<CharacterController>();
    }

    private void Update() {
        MovePlayer();
    }

    void MovePlayer() {
        if (rolling) {
            return;
        }
        Vector3 direction = c.Movement.Move.ReadValue<Vector3>();

        if (direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            if (cC.isGrounded) {
                moveDir.y = -4.5f;
                airRolling = false;
            }

            cC.Move(moveDir * speed * Time.deltaTime);
        }
    }

    IEnumerator RollAction() {
        if (!cC.isGrounded) {
            airRolling = true;
        }

        rolling = true;
        float startTime = Time.time;
        Vector3 dir = rollPosition.position - transform.position;
        dir.Normalize();
        do {
            if (cC.isGrounded) {
                dir.y = -4.5f;
            } else {
                dir.y = 0f;
            }
            cC.Move(dir * rollSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        } while (Time.time < startTime + rollTime * Time.deltaTime);
        rolling = false;
    }

    void OnRoll() {
        if (airRolling) {
            return;
        }

        rollCoroutine = RollAction();
        if (!rolling) {
            StartCoroutine(rollCoroutine);
        }
    }
}