using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManegerSFX : MonoBehaviour
{
    public static float SFXvolume =1f;
    public AudioSource audioSource1;
    public Slider slider1;

    void Start()
    {
        slider1.value = audioSource1.volume;

        slider1.onValueChanged.AddListener(delegate { ChangeVolume(audioSource1, slider1.value); });
    }

    void ChangeVolume(AudioSource audioSrc, float volume)
    {
        audioSrc.volume = volume;
        SFXvolume = volume;
    }
}