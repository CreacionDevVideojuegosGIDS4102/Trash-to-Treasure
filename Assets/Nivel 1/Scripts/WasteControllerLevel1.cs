using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WasteControllerLevel1 : MonoBehaviour
{
    public AudioClip inorganicWasteSound;
    private AudioSource audioSource;
    private MovementControllerLevel1 movementController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            movementController = player.GetComponent<MovementControllerLevel1>();
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
                movementController.organicWasteCollected++;
                movementController.UpdateOrganicWasteCounter();
            }
            else if (gameObject.CompareTag("Inorganica"))
            {
                if (inorganicWasteSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(inorganicWasteSound, 0.8f);
                }
                movementController.ReduceLife(10);
            }
        }
    }
}
