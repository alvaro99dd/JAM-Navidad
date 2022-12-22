using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gamePaused;
    public GameObject pauseMenu;
    public Text waterRunes, earthRunes, fireRunes;

    public static GameManager instance;

    private void Awake() {
        if (!instance) {
            instance = this;
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnPause() {
        gamePaused = !gamePaused;
        pauseMenu.SetActive(gamePaused);
        Time.timeScale = gamePaused ? 0 : 1;
    }
}
