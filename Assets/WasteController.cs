/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteController : MonoBehaviour
{
    public AudioClip inorganicWasteSound;
    private AudioSource audioSource;
    private MonoBehaviour movementController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            movementController = player.GetComponent<MonoBehaviour>();
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
                // Enviar la lógica de recolección de residuos a través del controlador adecuado
                var collectMethod = movementController.GetType().GetMethod("CollectOrganicWaste");
                if (collectMethod != null)
                {
                    collectMethod.Invoke(movementController, null);
                }
            }
            else if (gameObject.CompareTag("Inorganica"))
            {
                if (inorganicWasteSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(inorganicWasteSound, 0.8f);
                }

                // Llamar al método de reducir vida
                var reduceLifeMethod = movementController.GetType().GetMethod("ReduceLife");
                if (reduceLifeMethod != null)
                {
                    reduceLifeMethod.Invoke(movementController, new object[] { 10 });
                }
            }
        }
    }
}*/