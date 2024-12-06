using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLevelFour : MonoBehaviour
{
    public GameObject target; // El objetivo que la cámara seguirá
    public float speed = 5f;  // Velocidad del movimiento de la cámara
    public bool encendida = true;

    // Límites de la cámara
    public float derechaMax = 193.5f;   
    public float izquierdaMax = -19.2f;
    public float alturaMax = 25.8f;
    public float alturaMin = -25.8f;

    void Start()
    {
        // Si no se asigna un objetivo manual, intenta encontrarlo automáticamente
        if (target == null)
        {
            GameObject foundTarget = GameObject.FindWithTag("Player");

            // Verifica que el objetivo encontrado no sea el SpawnPoint
            if (foundTarget != null && foundTarget.name != "SpawnPoint")
            {
                target = foundTarget;
                Debug.Log("Objetivo encontrado automáticamente: " + target.name);
            }
            else
            {
                Debug.LogWarning("El objetivo encontrado es el SpawnPoint o no se encontró ningún objetivo.");
            }
        }
    }

    public void AssignPlayer(GameObject playerInstance)
    {
        if (playerInstance != null)
        {
            target = playerInstance;
            Debug.Log("Nuevo objetivo asignado a la cámara: " + target.name);
        }
        else
        {
            Debug.LogError("Intento de asignar un objetivo nulo.");
        }
    }

    public void SetLevelSpecificBehavior(string levelName)
    {
        switch (levelName)
        {
            case "LevelFour":
                Debug.Log("Configurando comportamiento específico para LevelFour.");
                derechaMax = 193.5f; // Cambiar los límites como ejemplo
                izquierdaMax = -19.2f;
                break;

            default:
                Debug.Log("Nivel no reconocido, utilizando configuración predeterminada.");
                derechaMax = 193.5f;
                izquierdaMax = -19.2f;
                break;
        }
    }

    void Move_Cam()
    {
        if (encendida && target != null)
        {
            Vector3 targetPosition = target.transform.position;

            // Limitar la posición dentro de los límites definidos
            targetPosition.x = Mathf.Clamp(targetPosition.x, izquierdaMax, derechaMax);
            targetPosition.y = Mathf.Clamp(targetPosition.y, alturaMin, alturaMax);
            targetPosition.z = -10f; // Ajusta la posición Z para 2D

            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    void Update()
    {
        Move_Cam();
    }
}