using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource backgroundMusic; // Música de fondo
    public AudioSource soundEffects; // Efectos de sonido

    public AudioClip organicWasteCollectedClip; // Sonido al recolectar basura orgánica
    public AudioClip carnivorousPlantClip; // Sonido al chocar con plantas carnívoras

    private void Awake()
    {
        // Asegura que solo haya un AudioManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persistente entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        if (soundEffects != null && clip != null)
        {
            soundEffects.PlayOneShot(clip);
        }
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.loop = true; // Loops indefinitely
            backgroundMusic.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
    }
}
