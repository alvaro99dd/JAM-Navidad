using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour {
    public GameObject cam;
    public GameObject aimCamera;
    public Transform head;

    public bool isAiming = false;

    public static CameraManager instance;

    private void Awake() {
        if (!instance) {
            instance = this;
        }
    }

    private void Update() {
        if (!isAiming) {
            aimCamera.transform.LookAt(head);
        }
    }

    public void AimBehaviour(InputAction.CallbackContext context) {

        if (context.started) {
            cam.SetActive(false);
            aimCamera.SetActive(true);
            isAiming = true;
        }
        if (context.canceled) {
            cam.SetActive(true);
            aimCamera.SetActive(false);
            isAiming = false;
        }
    }
}
