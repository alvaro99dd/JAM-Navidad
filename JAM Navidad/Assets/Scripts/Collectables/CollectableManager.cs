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
    public int currentWaterRunes, currentEarthRunes, currentFireRunes;
    public int maxWaterRunes, maxEarthRunes, maxFireRunes;

    public PlayerJump pJ;
    public static CollectableManager instance;

    private void Awake() {
        if (!instance) {
            instance = this;
        }
        Setup();
    }

    public void CheckCollectable() {
        switch (collectables) {
            case Collectables.rune:
                RuneBehaviour();
                break;
            case Collectables.babySloth:
                break;
            default:
                break;
        }
    }

    void RuneBehaviour() {
        switch (runeType) {
            case RuneType.earth:
                staffJump = ++currentEarthRunes >= maxEarthRunes;
                GameManager.instance.earthRunes.text = $"{currentEarthRunes} / {maxEarthRunes}";
                break;
            case RuneType.water:
                staffThrow = ++currentWaterRunes >= maxWaterRunes;
                GameManager.instance.waterRunes.text = $"{currentWaterRunes} / {maxWaterRunes}";
                break;
            case RuneType.fire:
                staffTravel = ++currentFireRunes >= maxFireRunes;
                GameManager.instance.fireRunes.text = $"{currentFireRunes} / {maxFireRunes}";
                break;
            default:
                break;
        }

        Debug.LogWarning("CAMBIAR METAS");
    }

    void Setup() {
        Transform runeParent = transform.Find("Runes");
        maxEarthRunes = runeParent.GetChild(0).childCount;
        maxWaterRunes = runeParent.GetChild(1).childCount;
        maxFireRunes = runeParent.GetChild(2).childCount;
    }
}
