using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GuideManager : MonoBehaviour {
    public GameObject fireRuneWindow;
    public GameObject earthRuneWindow;
    public GameObject waterRuneWindow;

    public bool isGuideShowing;

    public static GuideManager instance;

    private void Awake() {
        if (!instance) {
            instance = this;
        }
    }

    public void ShowMessage(string runeType) {

        if (runeType == "fire") {
            fireRuneWindow.SetActive(true);

        }
        if (runeType == "water") {
            waterRuneWindow.SetActive(true);

        }
        if (runeType == "earth") {
            earthRuneWindow.SetActive(true);

        }
        GameManager.instance.cinemachineFreeL.enabled = false;
        GameManager.instance.playerInput.enabled = false;
        isGuideShowing = true;
        Time.timeScale = 0;
    }

    public void HideMessage(InputAction.CallbackContext context) {
       

        if (fireRuneWindow.activeInHierarchy) {
            fireRuneWindow.SetActive(false);

            GameManager.instance.cinemachineFreeL.enabled = true;
            GameManager.instance.playerInput.enabled = true;
            isGuideShowing = false;


            Time.timeScale = 1;
        }
        if (waterRuneWindow.activeInHierarchy) {
            waterRuneWindow.SetActive(false);

            GameManager.instance.cinemachineFreeL.enabled = true;
            GameManager.instance.playerInput.enabled = true;
            isGuideShowing = false;

            Time.timeScale = 1;
        }
        if (earthRuneWindow.activeInHierarchy) {
            earthRuneWindow.SetActive(false);

            GameManager.instance.cinemachineFreeL.enabled = true;
            GameManager.instance.playerInput.enabled = true;
            isGuideShowing = false;

            Time.timeScale = 1;
        }
    }
}
