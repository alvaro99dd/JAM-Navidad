using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelToStaff : MonoBehaviour
{
    Transform playerStandingPoint;
    StaffBehaviour sB;
    public Transform player;
    CharacterController playercC;
    public PlayerJump pJ;
    public PlayerController pC;
    public Coroutine travelStaff;
    public float timeToTravel;
    bool collision;
    public bool hanged;

    private void Awake() {
        playercC = player.GetComponent<CharacterController>();
        pJ = player.GetComponent<PlayerJump>();
        pC = player.GetComponent<PlayerController>();
        playerStandingPoint = transform.GetChild(0);
        sB = GetComponent<StaffBehaviour>();
    }

    void OnTravel() {
        if (!CollectableManager.instance.staffTravel || pC.rolling || !sB.collide || travelStaff != null || sB.transform.parent != null || hanged) {
            return;
        }
        Vector3 dir = playerStandingPoint.position - player.position;
        if (Vector3.Distance(playerStandingPoint.position, player.position) < 10) {
            timeToTravel = 3f;
        } else {
            timeToTravel = 1f;
        }
        travelStaff = StartCoroutine(MoveToStaff(dir));
    }

    IEnumerator MoveToStaff(Vector3 dir) {
        //GetComponent<Collider>().isTrigger = true;
        pC.enabled = false;
        pJ.enabled = false;
        Physics.IgnoreLayerCollision(6, 7, true);
        while (!collision) {
            playercC.Move(dir * timeToTravel * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        //GetComponent<Collider>().isTrigger = false;
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
        StartCoroutine(ActivateCollision());
    }

    IEnumerator ActivateCollision() {
        yield return new WaitForSeconds(0.7f);
        Physics.IgnoreLayerCollision(6, 7, false);
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