using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gamePaused, UIshown;
    public GameObject pauseMenu, UI;
    public Text waterRunes, earthRunes, fireRunes, slothText;
    public Text UIWaterRunes, UIEarthRunes, UIFireRunes, UISlothText;
    public float disappearTime;
    Controls c;

    public static GameManager instance;

    private void Awake() {
        if (!instance) {
            instance = this;
        }
        c = new Controls();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        UIWaterRunes.text = waterRunes.text;
        UIEarthRunes.text = earthRunes.text;
        UIFireRunes.text = fireRunes.text;
        UISlothText.text = slothText.text;
    }

    void OnPause() {
        gamePaused = !gamePaused;
        pauseMenu.SetActive(gamePaused);
        Cursor.lockState = gamePaused ? CursorLockMode.Confined : CursorLockMode.Locked;
        Time.timeScale = gamePaused ? 0 : 1;
    }

    public void OnShowUI() {
        if (UIshown) {
            return;
        }
        UIshown = true;
        UI.GetComponent<Animator>().SetTrigger("Appear");
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear() {
        yield return new WaitForSeconds(disappearTime);
        UI.GetComponent<Animator>().SetTrigger("Disappear");
        //yield return new WaitForSeconds(0.5f);
        UIshown = false;
    }
}
