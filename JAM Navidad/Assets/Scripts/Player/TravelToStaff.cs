using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelToStaff : MonoBehaviour
{
    Transform playerStandingPoint;
    public Transform player;
    CharacterController playercC;
    public PlayerJump pJ;
    public PlayerController pC;
    public Coroutine travelStaff;
    public float minDistance;
    public float timeToTravel;
    bool collision;
    public bool hanged;

    private void Awake() {
        playercC = player.GetComponent<CharacterController>();
        pJ = player.GetComponent<PlayerJump>();
        pC = player.GetComponent<PlayerController>();
        playerStandingPoint = transform.GetChild(0);
    }

    void OnTravel() {
        if (transform.parent || travelStaff != null) {
            return;
        }
        Vector3 dir = playerStandingPoint.position - player.position;
        travelStaff = StartCoroutine(MoveToStaff(dir));
    }

    IEnumerator MoveToStaff(Vector3 dir) {
        pJ.enabled = false;
        pC.enabled = false;
        //GetComponent<Collider>().isTrigger = true;
        Physics.IgnoreLayerCollision(6, 7, true);
        while (!collision) {
            playercC.Move(dir * timeToTravel * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        //GetComponent<Collider>().isTrigger = false;
        Physics.IgnoreLayerCollision(6, 7, false);
        travelStaff = null;
        collision = false;
        HangOnStaff();
    }

    void HangOnStaff() {
        playercC.enabled = false;
        pJ.enabled = true;
        pC.enabled = true;
        hanged = true;
    }

    //LLAMAR CUANDO EL JUGADOR SALTE O SUBA
    //AL SALTAR LLEVARSE EL BASTON CON EL
    //AL PULSAR W SUBIR
    public void StopHanging() {
        playercC.enabled = true;
        hanged = false;
    }

    public void CancelTravel() {
        StopCoroutine(travelStaff);
        travelStaff = null;
        pC.enabled = true;
        pJ.enabled = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (travelStaff != null && other.CompareTag("Player")) {
            collision = true;
        }
    }
}