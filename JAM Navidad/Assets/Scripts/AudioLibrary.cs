using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLibrary : MonoBehaviour
{
    public AudioClip steps;
    public AudioClip jump;
    public AudioClip roll;
    public AudioClip throwStaff;
    public AudioClip travel;
    public AudioClip collectRune;
    public AudioClip collectSloth;
    public AudioClip powerUp;

    public static AudioLibrary instance;

    private void Awake() {
        if (!instance) {
            instance = this;
        }
    }
}
