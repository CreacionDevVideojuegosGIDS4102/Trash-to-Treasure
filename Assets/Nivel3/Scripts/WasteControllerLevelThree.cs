using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WasteControllerLevelThree : MonoBehaviour
{
    public AudioClip inorganicWasteSound;
    private AudioSource audioSource;
    private MovementControllerLevelThree movementControllerLevelThree;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            movementControllerLevelThree = player.GetComponent<MovementControllerLevelThree>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (movementControllerLevelThree == null) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Organica"))
            {
                Destroy(gameObject);
                //movementControllerLevelThree.organicWasteCollected++;
                //movementControllerLevelThree.UpdateOrganicWasteCounter();
                movementControllerLevelThree.CollectOrganicWaste();
            }
            else if (gameObject.CompareTag("Carnibora"))
            {
                AudioManager.instance.PlaySoundEffect(AudioManager.instance.carnivorousPlantClip);
                movementControllerLevelThree.ReduceLife(30);
            }
        }
    }
}
