using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToxicPoolControllerLevelThree : MonoBehaviour
{
    public AudioClip gameOverSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameOverSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(gameOverSound, 0.8f);
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
