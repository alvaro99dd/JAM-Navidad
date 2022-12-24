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
                            for (int i = 0; i < CollectableManager.instance.maxEarthRunes; i++) {
                                if (CollectableManager.instance.runeParent.GetChild(0).GetChild(i).name == transform.name) {
                                    PlayerPrefs.SetInt($"Earth{i}", 1);
                                }
                            }
                            break;
                        case RuneType.water:
                            CollectableManager.instance.runeType = RuneType.water;
                            for (int i = 0; i < CollectableManager.instance.maxWaterRunes; i++) {
                                if (CollectableManager.instance.runeParent.GetChild(1).GetChild(i).name == transform.name) {
                                    PlayerPrefs.SetInt($"Water{i}", 1);
                                }
                            }
                            break;
                        case RuneType.fire:
                            CollectableManager.instance.runeType = RuneType.fire;
                            for (int i = 0; i < CollectableManager.instance.maxFireRunes; i++) {
                                if (CollectableManager.instance.runeParent.GetChild(2).GetChild(i).name == transform.name) {
                                    PlayerPrefs.SetInt($"Fire{i}", 1);
                                }
                            }
                            break;
                        default:
                            break;
                    }

                    break;
                case "BabySloth":
                    CollectableManager.instance.collectables = Collectables.babySloth;
                    other.GetComponent<AudioSource>().PlayOneShot(AudioLibrary.instance.collectSloth);
                    for (int i = 0; i < CollectableManager.instance.maxSloths; i++) {
                        if (CollectableManager.instance.slothParent.GetChild(i).name == transform.name) {
                            PlayerPrefs.SetInt($"BabySloths{i}", 1);
                        }
                    }
                    break;
                default:
                    break;
            }
            CollectableManager.instance.CheckCollectable();
            gameObject.SetActive(false);

        }
    }
}