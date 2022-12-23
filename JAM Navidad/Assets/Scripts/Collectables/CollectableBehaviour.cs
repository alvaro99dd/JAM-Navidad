using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RuneType {
    earth, water, fire, none
}

public class CollectableBehaviour : MonoBehaviour {
    public RuneType runeType;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            switch (tag) {
                case "Rune":
                    CollectableManager.instance.collectables = Collectables.rune;
                    switch (runeType) {
                        case RuneType.earth:
                            CollectableManager.instance.runeType = RuneType.earth;
                            break;
                        case RuneType.water:
                            CollectableManager.instance.runeType = RuneType.water;
                            break;
                        case RuneType.fire:
                            CollectableManager.instance.runeType = RuneType.fire;
                            break;
                        default:
                            break;
                    }

                    break;
                case "BabySloth":
                    CollectableManager.instance.collectables = Collectables.babySloth;
                    break;
                default:
                    break;
            }
            CollectableManager.instance.CheckCollectable();
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
