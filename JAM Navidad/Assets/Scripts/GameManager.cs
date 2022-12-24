using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {
    bool gamePaused, UIshown;
    public GameObject pauseMenu, UI;
    public CinemachineFreeLook cinemachineFreeL;
    public PlayerInput playerInput;
    public string waterRunes, earthRunes, fireRunes, slothText;
    public Text UIWaterRunes, UIEarthRunes, UIFireRunes, UISlothText;
    public AudioSource playerAS, cameraAS;
    public Slider musicSlider, soundSlider;
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

    private void Start() {
        OnShowUI();
    }

    private void Update() {
        UIWaterRunes.text = waterRunes;
        UIEarthRunes.text = earthRunes;
        UIFireRunes.text = fireRunes;
        UISlothText.text = slothText;
    }

    public void OnPause() {
        if (GuideManager.instance.isGuideShowing) {
            GuideManager.instance.isGuideShowing = false;
            return;
        }

        gamePaused = !gamePaused;
        cinemachineFreeL.gameObject.SetActive(!gamePaused);
        playerInput.enabled = !gamePaused;
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

    public void Exit() {
        Application.Quit();
    }

    public void ChangeMusicVolume() {
        cameraAS.volume = musicSlider.value;
    }

    public void ChangeSoundVolume() {
        playerAS.volume = soundSlider.value;
    }
}
