using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteControllerLevelThree : MonoBehaviour
{
    public string wasteName = "Apple (3)"; // Nombre del objeto específico.

    private MovementController movementController;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            movementController = player.GetComponent<MovementController>();
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
                movementController.CollectOrganicWaste();
            }
            else if (gameObject.CompareTag("Carnibora"))
            {
                movementController.ReduceLife(30);
            }
        }
    }
}
