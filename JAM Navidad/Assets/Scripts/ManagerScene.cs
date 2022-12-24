using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    bool controlsShown;
    AudioSource aS;
    public GameObject controls;

    private void Awake() {
        GetComponent<AudioSource>();
    }

    public void Play() {
        aS.PlayOneShot(AudioLibrary.instance.button);
        SceneManager.LoadScene("TestingScene");
    }

    public void Controls() {
        aS.PlayOneShot(AudioLibrary.instance.button);
        controlsShown = !controlsShown;
        controls.SetActive(controlsShown);
    }

    public void Exit() {
        aS.PlayOneShot(AudioLibrary.instance.button);
        Application.Quit();
    }
}
