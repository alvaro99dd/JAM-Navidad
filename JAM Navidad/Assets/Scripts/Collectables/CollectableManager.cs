using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Collectables {
    rune, babySloth
}

public class CollectableManager : MonoBehaviour {
    public Collectables collectables;
    //CAMBIAR
    const int runeGoal1 = 1, runeGoal2 = 3, runeGoal3 = 5;
    public bool staffThrow;
    public bool staffJump;
    public int runes;

    public PlayerJump pJ;
    public static CollectableManager instance;

    private void Awake() {
        if (!instance) {
            instance = this;
        }
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
        switch (++runes) {
            case runeGoal1:
                staffJump = true;
                break;
            case runeGoal2:
                staffThrow = true;
                break;
            case runeGoal3:
                break;
            default:
                break;
        }
        Debug.LogWarning("CAMBIAR METAS");
    }
}
