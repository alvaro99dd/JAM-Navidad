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
                    GuideManager.instance.ShowMessage("earth");
                    PlayerPrefs.SetInt("Throw", 1);
                }

                GameManager.instance.earthRunes.text = $"{currentEarthRunes} / {maxEarthRunes}";
                PlayerPrefs.SetInt("EarthRunes", currentEarthRunes);
                break;
            case RuneType.water:
                staffTravel = ++currentWaterRunes >= maxWaterRunes;

                if (staffTravel) {
                    GuideManager.instance.ShowMessage("water");
                    PlayerPrefs.SetInt("Travel", 1);
                }

                GameManager.instance.waterRunes.text = $"{currentWaterRunes} / {maxWaterRunes}";
                PlayerPrefs.SetInt("WaterRunes", currentWaterRunes);
                break;
            case RuneType.fire:
                staffJump = ++currentFireRunes >= maxFireRunes;

                if (staffJump) {
                    GuideManager.instance.ShowMessage("fire");
                    PlayerPrefs.SetInt("Jump", 1);
                }

                GameManager.instance.fireRunes.text = $"{currentFireRunes} / {maxFireRunes}";
                PlayerPrefs.SetInt("FireRunes", currentFireRunes);
                break;
        }

        Debug.LogWarning("CAMBIAR METAS");
    }

    void SlothBehaviour() {
        GameManager.instance.slothText.text = $"{++currentSloths} / {maxSloths}";
        PlayerPrefs.SetInt("BabySloths", currentSloths);
    }

    void LoadData() {
        if (PlayerPrefs.HasKey("EarthRunes")) {
            GameManager.instance.earthRunes.text = $"{PlayerPrefs.GetInt("EarthRunes")} / {maxEarthRunes}";
        } else {
            GameManager.instance.earthRunes.text = $"{currentEarthRunes} / {maxEarthRunes}";
        }

        if (PlayerPrefs.HasKey("WaterRunes")) {
            GameManager.instance.waterRunes.text = $"{PlayerPrefs.GetInt("WaterRunes")} / {maxWaterRunes}";
        } else {
            GameManager.instance.waterRunes.text = $"{currentWaterRunes} / {maxWaterRunes}";
        }

        if (PlayerPrefs.HasKey("FireRunes")) {
            GameManager.instance.fireRunes.text = $"{PlayerPrefs.GetInt("FireRunes")} / {maxFireRunes}";
        } else {
            GameManager.instance.fireRunes.text = $"{currentFireRunes} / {maxFireRunes}";
        }

        if (PlayerPrefs.HasKey("BabySloths")) {
            GameManager.instance.slothText.text = $"{PlayerPrefs.GetInt("BabySloths")} / {maxSloths}";
        } else {
            GameManager.instance.slothText.text = $"{currentSloths} / {maxSloths}";
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
