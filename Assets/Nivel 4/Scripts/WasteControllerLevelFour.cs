using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WasteControllerLevelFour : MonoBehaviour
{
    public AudioClip inorganicWasteSound;
    private AudioSource audioSource;
    private MovementControllerLevelFour movementController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            movementController = player.GetComponent<MovementControllerLevelFour>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (movementController == null) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Organica"))
            {
                Destroy(gameObject);
                movementController.CollectOrganicWaste(); // Usa la nueva lógica
            }
            else if (gameObject.CompareTag("Inorganica"))
            {
                if (inorganicWasteSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(inorganicWasteSound, 0.8f);
                }
                movementController.ReduceLife(10);
            }
            else if (gameObject.CompareTag("Cambio"))
            {
                // Cambiar al siguiente nivel
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
