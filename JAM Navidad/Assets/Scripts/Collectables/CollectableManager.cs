using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Collectables {
    rune, babySloth
}

public class CollectableManager : MonoBehaviour {
    public Collectables collectables;
    public RuneType runeType;
    //CAMBIAR
    public bool staffThrow;
    public bool staffJump;
    public bool staffTravel;
    public int currentWaterRunes, currentEarthRunes, currentFireRunes, currentSloths;
    public int maxWaterRunes, maxEarthRunes, maxFireRunes, maxSloths;

    public PlayerJump pJ;
    public static CollectableManager instance;

    private void Awake() {
        if (!instance) {
            instance = this;
        }
        Setup();
    }

    private void Start() {
        GameManager.instance.earthRunes.text = $"{currentEarthRunes} / {maxEarthRunes}";
        GameManager.instance.waterRunes.text = $"{currentWaterRunes} / {maxWaterRunes}";
        GameManager.instance.fireRunes.text = $"{currentFireRunes} / {maxFireRunes}";
        GameManager.instance.slothText.text = $"{currentSloths} / {maxSloths}";
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
                }

                GameManager.instance.earthRunes.text = $"{currentEarthRunes} / {maxEarthRunes}";
                break;
            case RuneType.water:
                staffTravel = ++currentWaterRunes >= maxWaterRunes;

                if (staffTravel) {
                    GuideManager.instance.ShowMessage("water");
                }

                GameManager.instance.waterRunes.text = $"{currentWaterRunes} / {maxWaterRunes}";
                break;
            case RuneType.fire:
                staffJump = ++currentFireRunes >= maxFireRunes;

                if (staffTravel) {
                    GuideManager.instance.ShowMessage("fire");
                }

                GameManager.instance.fireRunes.text = $"{currentFireRunes} / {maxFireRunes}";
                break;
        }

        Debug.LogWarning("CAMBIAR METAS");
    }

    void SlothBehaviour() {
        GameManager.instance.slothText.text = $"{++currentSloths} / {maxSloths}";
    }

    void Setup() {
        Transform runeParent = transform.Find("Runes");
        Transform slothParent = transform.Find("BabySloths");
        maxEarthRunes = runeParent.GetChild(0).childCount;
        maxWaterRunes = runeParent.GetChild(1).childCount;
        maxFireRunes = runeParent.GetChild(2).childCount;
        maxSloths = slothParent.childCount;
    }
}
