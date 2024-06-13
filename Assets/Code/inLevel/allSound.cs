using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allSound : MonoBehaviour
{
    [Header("------------- Audio Source --------------")]
    [SerializeField] AudioSource MusicSource; // Audio source for background music
    [SerializeField] AudioSource winAndLossSound; // Audio source for win and loss sounds
    [SerializeField] AudioSource SFXSource; // Audio source for sound effects

    [Header("------------- Audio Clip --------------")]
    public AudioClip BG; // Background music clip
    public AudioClip TrueAnswer; // Clip for correct answer sound
    public AudioClip FalseAnswer; // Clip for incorrect answer sound
    public AudioClip ClickBtn; // Clip for button click sound
    public AudioClip YouWin; // Clip for win sound
    public AudioClip YouLoss; // Clip for loss sound
    public AudioClip ErrorSound; // Clip for error sound
    public AudioClip warriningSound; // Clip for warning sound

    static float VolumSFX = 1f; // Volume level for sound effects
    static float VolumBG = 1f; // Volume level for background music

    // Start is called before the first frame update
    void Start()
    {
        // Play background music at the start of the game
        MusicSource.clip = BG; // Set the background music clip
        MusicSource.Play(); // Play the background music
        // Set the volume of the background music
        MusicSource.volume = VolumBG;
    }

    void Update()
    {
        // Update the volume levels from the sound manager
        VolumSFX = SoundManegerSFX.SFXvolume;
        VolumBG = SoundManegerMusic.BGvalume;
    }

    public void trueAnswerClick()
    {
        // Play the sound for a correct answer
        SFXSource.PlayOneShot(TrueAnswer, VolumSFX);
    }

    public void falseAnswerClick()
    {
        // Play the sound for an incorrect answer
        SFXSource.PlayOneShot(FalseAnswer, VolumSFX);
    }

    public void soundClick()
    {
        // Play the sound for a button click
        SFXSource.PlayOneShot(ClickBtn, VolumSFX);
    }

    public void soundYouWin()
    {
        // Play the sound for winning
        MusicSource.volume = 0; // Mute the background music
        winAndLossSound.volume = VolumSFX; // Set the volume for the win sound
        winAndLossSound.clip = YouWin; // Set the win sound clip
        winAndLossSound.Play(); // Play the win sound
    }

    public void soundYouLoss()
    {
        // Play the sound for losing
        MusicSource.volume = 0; // Mute the background music
        winAndLossSound.volume = VolumSFX; // Set the volume for the loss sound
        winAndLossSound.clip = YouLoss; // Set the loss sound clip
        winAndLossSound.Play(); // Play the loss sound
    }

    public void ShowError()
    {
        // Play the error sound
        SFXSource.PlayOneShot(ErrorSound, VolumSFX);
    }

    public void ShowWarrining()
    {
        // Play the warning sound
        SFXSource.PlayOneShot(warriningSound, VolumSFX);
    }
}
