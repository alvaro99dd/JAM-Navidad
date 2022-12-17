using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            switch (tag) {
                case "Rune":
                    CollectableManager.instance.collectables = Collectables.rune;
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
