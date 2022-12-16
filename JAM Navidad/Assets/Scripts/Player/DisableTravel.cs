using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTravel : MonoBehaviour {
    public TravelToStaff toStaff;
    CharacterController cC;

    private void Awake() {
       cC = GetComponent<CharacterController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (!cC.isGrounded && toStaff.travelStaff != null) {
            toStaff.CancelTravel();
        }
    }
}
