using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meditate : MonoBehaviour {
    public GameObject fadeFilter;
    Image fadeImage;
    LineRenderer line;
    public Transform runesContainer;
    float minDistance;
    bool meditating;

    private void Awake() {
        fadeImage = fadeFilter.GetComponent<Image>();
        line = GetComponentInChildren<LineRenderer>(true);
    }

    private void Update() {
        MeditateActions();
    }

    void MeditateActions() {

        if (meditating) {
            Vector3 runePosition;
            if (!CollectableManager.instance.staffTravel) {
                runePosition = Setup().position;
            } else {
                runePosition = transform.position;
            }

            fadeFilter.SetActive(true);

            line.gameObject.SetActive(true);
            line.positionCount = 2;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, runePosition);
        } else {
            if (fadeFilter.activeInHierarchy) {
                line.gameObject.SetActive(false);
                fadeFilter.SetActive(false);
            }
        }
    }

    void OnMeditate() {
        meditating = !meditating;
    }

    Transform Setup() {
        float currentDistance;
        Transform runeToSearch = runesContainer.GetChild(0);

        minDistance = Vector3.Distance(transform.position, runesContainer.GetChild(0).position);
        for (int i = 0; i < runesContainer.childCount; i++) {
            for (int x = 0; x < runesContainer.GetChild(i).childCount; x++) {
                currentDistance = Vector3.Distance(transform.position, runesContainer.GetChild(i).GetChild(x).position);
                if (currentDistance < minDistance) {
                    minDistance = currentDistance;
                    runeToSearch = runesContainer.GetChild(i).GetChild(x);
                }
            }
        }

        return runeToSearch;

        //foreach (Transform item in runesContainer.GetComponentInChildren<Transform>()) {
        //    currentDistance = Vector3.Distance(transform.position, item.position);
        //    if (currentDistance < minDistance) {
        //        minDistance = currentDistance;
        //        runeToSearch = item;
        //    }
        //}

        //return runeToSearch;
    }
}
