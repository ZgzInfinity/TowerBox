
/*
 * ------------------------------------------
 * -- Project: Tower Box --------------------
 * -- Author: Rubén Rodríguez Estebban ------
 * -- Date: 8/10/2021 -----------------------
 * ------------------------------------------
 */

using UnityEngine;

/**
 * Script that controls the reproduction of the sounds
 */

public class AudioManager : MonoBehaviour
{
    // Static instance of the class
    public static AudioManager Instance;

    // Reference to the music reproductor
    public AudioSource musicAudioSource;

    // Reference to the effects reproductor
    public AudioSource effectsAudioSource;

    // Constructor
    private void Awake()
    {
        Instance = this;
    }

    // Reproduce a sound of the game
    public void PlaySound(Sound sound)
    {
        // Check if the sound is a music or an effect
        if (sound.soundType == Sound.SoundType.MUSIC)
        {
            // Music
            playMausic(sound);
        }
        else if (sound.soundType == Sound.SoundType.FX)
        {
            // Effect
            playFx(sound);
        }
    }

    // Play music
    private void playMausic(Sound sound)
    {
        // Set the clip with the volume and the loop options
        musicAudioSource.clip = sound.clip;
        musicAudioSource.volume = sound.volume;
        musicAudioSource.loop = sound.loop;

        // Play the music
        musicAudioSource.Play();
    }

    // Play effect
    private void playFx(Sound sound)
    {
        // Set the clip with the volume and the loop options
        effectsAudioSource.clip = sound.clip;
        effectsAudioSource.volume = sound.volume;
        effectsAudioSource.loop = sound.loop;

        // Play the effect
        effectsAudioSource.Play();
    }
}
