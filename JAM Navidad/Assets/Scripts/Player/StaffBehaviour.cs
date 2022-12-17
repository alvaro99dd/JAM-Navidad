using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StaffBehaviour : MonoBehaviour {
    Rigidbody rB;
    Transform parent;
    Collider objectCollider;
    TravelToStaff travelScript;
    //AnimationCurve yCurve;
    public Transform staffLimit;
    public Transform reference;
    Vector3 tempPosition;
    string tempTag;
    bool lerping;
    bool comingBack;
    public bool collide;

    public float throwSpeed;
    public float maxDistance;
    public float minDistance;
    public float antiBugDistance;
    public LayerMask interactableLayers;
    public float time;
    public IEnumerator staffCoroutine;
    Coroutine goBack;
    public float goBackTimer;

    private void Awake() {
        rB = GetComponent<Rigidbody>();
        parent = transform.parent;
        travelScript = GetComponent<TravelToStaff>();
        objectCollider = GetComponent<Collider>();
    }

    private void FixedUpdate() {
        RelocateLimit();

        if (rB.velocity.magnitude > Vector3.zero.magnitude) {
            rB.velocity = Vector3.zero;
            rB.angularVelocity = Vector3.zero;
        }
    }

    void RelocateLimit() {
        Ray cameraRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, maxDistance, interactableLayers)) {
            staffLimit.position = hitInfo.point;
            staffLimit.tag = hitInfo.transform.tag;
        } else {
            staffLimit.position = reference.position;
            staffLimit.tag = reference.tag;
        }
    }

    void OnThrow() {
        if (!CollectableManager.instance.staffThrow) {
            return;
        }
        staffCoroutine = LerpPosition();
        if (!transform.parent && !comingBack) {
            if (goBack != null) {
                StopCoroutine(goBack);
            }
            if (travelScript.travelStaff != null) {
                travelScript.CancelTravel();
            }
            if (travelScript.hanged) {
                travelScript.hanged = false;
                travelScript.StopHanging();
            }
            StartCoroutine(BackToPlayer());
        }

        if (!lerping && !comingBack) {
            StartCoroutine(staffCoroutine);
        }

    }

    IEnumerator LerpPosition() {
        tempPosition = staffLimit.position;
        tempTag = staffLimit.tag;

        lerping = true;
        transform.SetParent(null);

        while (Vector3.Distance(transform.position, tempPosition) > minDistance) {
            rB.position = Vector3.MoveTowards(transform.position, tempPosition, time * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        //CheckTag();
        lerping = false;
        objectCollider.enabled = true;
        goBack = StartCoroutine(GoBackCountdown());
    }

    IEnumerator BackToPlayer() {
        objectCollider.enabled = false;
        rB.isKinematic = false;
        comingBack = true;
        tempPosition = parent.position;
        transform.rotation = Quaternion.Euler(Vector3.zero);

        while (Vector3.Distance(transform.position, tempPosition) > minDistance) {
            tempPosition = parent.position;
            rB.position = Vector3.MoveTowards(transform.position, tempPosition, time * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        rB.velocity = Vector3.zero;
        transform.SetParent(parent);
        comingBack = false;
        collide = false;
    }

    IEnumerator GoBackCountdown() {
        if (!collide) {
            yield return new WaitForSeconds(goBackTimer);
            StartCoroutine(BackToPlayer());
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (transform.parent || comingBack) {
            return;
        }

        if (tempTag == "Floor" || tempTag == "Wall") {
            if (goBack != null) {
                StopCoroutine(goBack);
            }
            //StopCoroutine(staffCoroutine);
            lerping = false;
            collide = true;
            objectCollider.enabled = true;

            rB.velocity = Vector3.zero;
            rB.angularVelocity = Vector3.zero;

            Vector3 dir = tempPosition - transform.position;
            dir = -dir.normalized;

            transform.up = dir;
            rB.position = new Vector3(tempPosition.x, tempPosition.y, tempPosition.z);
            if (Vector3.Distance(parent.position, transform.position) < antiBugDistance) {
                rB.isKinematic = true;
            }
        } else {
            StartCoroutine(BackToPlayer());
        }
    }
}
