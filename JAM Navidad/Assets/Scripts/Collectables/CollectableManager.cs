using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Collectables {
    rune, babySloth
}

public class CollectableManager : MonoBehaviour {
    public Collectables collectables;
    public RuneType runeType;

    public bool staffThrow;
    public bool staffJump;
    public bool staffTravel;
    public int currentWaterRunes, currentEarthRunes, currentFireRunes, currentSloths;
    public int maxWaterRunes, maxEarthRunes, maxFireRunes, maxSloths;

    public Transform runeParent, slothParent;

    public PlayerJump pJ;
    public static CollectableManager instance;

    private void Awake() {
        if (!instance) {
            instance = this;
        }
        runeParent = transform.Find("Runes");
        slothParent = transform.Find("BabySloths");
        Setup();
    }

    private void Start() {
        LoadData();
    }

    public void CheckCollectable() {
        GameManager.instance.OnShowUI();
        switch (collectables) {
            case Collectables.rune:
                RuneBehaviour();
                break;
            case Collectables.babySloth:
                SlothBehaviour();
                break;

        }
    }

    void RuneBehaviour() {
        switch (runeType) {
            case RuneType.earth:
                staffThrow = ++currentEarthRunes >= maxEarthRunes;

                if (staffThrow) {
                    pJ.GetComponent<AudioSource>().PlayOneShot(AudioLibrary.instance.powerUp);
                    GuideManager.instance.ShowMessage("earth");
                    PlayerPrefs.SetInt("Throw", 1);
                } else {
                    pJ.GetComponent<AudioSource>().PlayOneShot(AudioLibrary.instance.collectRune);
                }

                GameManager.instance.earthRunes = $"{currentEarthRunes} / {maxEarthRunes}";
                PlayerPrefs.SetInt("EarthRunes", currentEarthRunes);
                break;
            case RuneType.water:
                staffTravel = ++currentWaterRunes >= maxWaterRunes;

                if (staffTravel) {
                    pJ.GetComponent<AudioSource>().PlayOneShot(AudioLibrary.instance.powerUp);
                    GuideManager.instance.ShowMessage("water");
                    PlayerPrefs.SetInt("Travel", 1);
                } else {
                    pJ.GetComponent<AudioSource>().PlayOneShot(AudioLibrary.instance.collectRune);
                }

                GameManager.instance.waterRunes = $"{currentWaterRunes} / {maxWaterRunes}";
                PlayerPrefs.SetInt("WaterRunes", currentWaterRunes);
                break;
            case RuneType.fire:
                staffJump = ++currentFireRunes >= maxFireRunes;

                if (staffJump) {
                    pJ.GetComponent<AudioSource>().PlayOneShot(AudioLibrary.instance.powerUp);
                    GuideManager.instance.ShowMessage("fire");
                    PlayerPrefs.SetInt("Jump", 1);
                } else {
                    pJ.GetComponent<AudioSource>().PlayOneShot(AudioLibrary.instance.collectRune);
                }

                GameManager.instance.fireRunes = $"{currentFireRunes} / {maxFireRunes}";
                PlayerPrefs.SetInt("FireRunes", currentFireRunes);
                break;
        }

        Debug.LogWarning("CAMBIAR METAS");
    }

    void SlothBehaviour() {
        GameManager.instance.slothText
            = $"{++currentSloths} / {maxSloths}";
        PlayerPrefs.SetInt("BabySloths", currentSloths);
    }

    void LoadData() {
        if (PlayerPrefs.HasKey("EarthRunes")) {
            GameManager.instance.earthRunes = $"{PlayerPrefs.GetInt("EarthRunes")} / {maxEarthRunes}";
            currentEarthRunes = PlayerPrefs.GetInt("EarthRunes");
        } else {
            GameManager.instance.earthRunes = $"{currentEarthRunes} / {maxEarthRunes}";
        }

        if (PlayerPrefs.HasKey("WaterRunes")) {
            GameManager.instance.waterRunes = $"{PlayerPrefs.GetInt("WaterRunes")} / {maxWaterRunes}";
            currentWaterRunes = PlayerPrefs.GetInt("WaterRunes");
        } else {
            GameManager.instance.waterRunes = $"{currentWaterRunes} / {maxWaterRunes}";
        }

        if (PlayerPrefs.HasKey("FireRunes")) {
            GameManager.instance.fireRunes = $"{PlayerPrefs.GetInt("FireRunes")} / {maxFireRunes}";
            currentFireRunes = PlayerPrefs.GetInt("FireRunes");
        } else {
            GameManager.instance.fireRunes = $"{currentFireRunes} / {maxFireRunes}";
        }

        if (PlayerPrefs.HasKey("BabySloths")) {
            GameManager.instance.slothText = $"{PlayerPrefs.GetInt("BabySloths")} / {maxSloths}";
        } else {
            GameManager.instance.slothText = $"{currentSloths} / {maxSloths}";
        }

        if (PlayerPrefs.HasKey("Throw")) {
            staffThrow = true;
        }

        if (PlayerPrefs.HasKey("Travel")) {
            staffTravel = true;
        }

        if (PlayerPrefs.HasKey("Jump")) {
            staffJump = true;
        }
    }

    void Setup() {
        maxEarthRunes = runeParent.GetChild(0).childCount;
        for (int i = 0; i < maxEarthRunes; i++) {
            if (PlayerPrefs.HasKey($"Earth{i}")) {
                runeParent.GetChild(0).GetChild(i).gameObject.SetActive(false);
            }
        }
        maxWaterRunes = runeParent.GetChild(1).childCount;
        for (int i = 0; i < maxWaterRunes; i++) {
            if (PlayerPrefs.HasKey($"Water{i}")) {
                runeParent.GetChild(1).GetChild(i).gameObject.SetActive(false);
            }
        }
        maxFireRunes = runeParent.GetChild(2).childCount;
        for (int i = 0; i < maxFireRunes; i++) {
            if (PlayerPrefs.HasKey($"Fire{i}")) {
                runeParent.GetChild(2).GetChild(i).gameObject.SetActive(false);
            }
        }
        maxSloths = slothParent.childCount;
        for (int i = 0; i < maxSloths; i++) {
            if (PlayerPrefs.HasKey($"BabySloths{i}")) {
                slothParent.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
