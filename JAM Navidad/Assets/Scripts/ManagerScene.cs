using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    bool controlsShown;
    public GameObject controls;

    public void Play() {
        SceneManager.LoadScene("TestingScene");
    }

    public void Controls() {
        controlsShown = !controlsShown;
        controls.SetActive(controlsShown);
    }

    public void Exit() {
        Application.Quit();
    }
}
