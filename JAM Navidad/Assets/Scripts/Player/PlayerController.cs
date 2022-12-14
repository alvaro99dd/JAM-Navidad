using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour {
    Controls c;
    CharacterController cC;
    public AudioSource aS;
    public Animator anim;
    float originalCenter;
    float originalHeight;
    public TravelToStaff toStaff;

    public Transform cam;
    public Transform rollPosition;

    public float speed;
    [Header("Turn to camera")]
    public float turnSmoothTime;
    public float turnSmoothVelocity;
    [Header("Roll")]
    public float rollDuration;
    public float rollSpeed;
    public bool rolling;
    public float colliderHeight;
    public float colliderCenter;
    [Header("Particles")]
    public GameObject walkParticles;
    public GameObject dashParticles;


    public float rollTime;
    public IEnumerator rollCoroutine;
    //Si queremos a?adir mas dashes en el aire hay que cambiarlo por un int (contador)
    public bool airRolling;

    private void Awake() {
        c = new Controls();
        c.Enable();
        cC = GetComponent<CharacterController>();
        originalCenter = cC.center.y;
        originalHeight = cC.height;
        anim = GetComponentInChildren<Animator>();
        aS = GetComponent<AudioSource>();
    }

    private void Update() {
        MovePlayer();

        anim.SetBool("Grounded", cC.isGrounded);
    }

    void MovePlayer() {
        if (rolling) {
            return;
        }
        Vector3 direction = c.Movement.Move.ReadValue<Vector3>();

        if (direction.magnitude >= 0.1f) {
            if (cC.isGrounded) {
                walkParticles.SetActive(true);
                if (!aS.isPlaying) {
                    aS.PlayOneShot(AudioLibrary.instance.steps);
                }
            } else {
                walkParticles.SetActive(false);

            }
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            if (cC.isGrounded) {
                moveDir.y = -4.5f;
                airRolling = false;
            }

            cC.Move(moveDir * speed * Time.deltaTime);
        } else {
            walkParticles.SetActive(false);

        }
        anim.SetFloat("Vspeed", direction.magnitude);
    }

    IEnumerator RollAction() {
        anim.ResetTrigger("Roll");
        anim.ResetTrigger("StopRoll");
        if (!cC.isGrounded) {
            airRolling = true;
        } else {
            cC.height = colliderHeight;
            cC.center = new Vector3(0, colliderCenter, 0);
        }
        anim.SetTrigger("Roll");
        dashParticles.SetActive(true);
        rolling = true;
        float startTime = Time.time;
        Vector3 dir = rollPosition.position - transform.position;
        dir.Normalize();
        aS.PlayOneShot(AudioLibrary.instance.roll);
        do {
            if (cC.isGrounded) {
                dir.y = -4.5f;
            } else {
                dir.y = 0f;
            }
            cC.Move(dir * rollSpeed * Time.deltaTime);
            yield return null;
        } while (Time.time < startTime + rollTime);
        rolling = false;
        cC.height = originalHeight;
        cC.center = new Vector3(0, originalCenter, 0);
        anim.SetTrigger("StopRoll");
        dashParticles.SetActive(false);
    }

    void OnRoll() {
        if (cC.isGrounded) {
            airRolling = false;
        }

        if (airRolling || toStaff.travelStaff != null) {
            return;
        }

        rollCoroutine = RollAction();
        if (!rolling) {
            StartCoroutine(rollCoroutine);
        }
    }
}