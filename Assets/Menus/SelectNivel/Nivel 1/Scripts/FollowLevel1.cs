using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLevelOne : MonoBehaviour
{
    public GameObject target; // El jugador que la cámara debe seguir
    public float derechaMax = 197.3f; // Límite derecho de la cámara
    public float izquierdaMax = -16.4f; // Límite izquierdo de la cámara
    public float alturaMax = 25.9f; // Altura máxima
    public float alturaMin = -25.9f; // Altura mínima
    public float speed = 5f; // Velocidad de la cámara
    public bool encendida = true; // Activar/desactivar el movimiento de la cámara

    void Start()
    {
        // Intentar encontrar el objetivo automáticamente si no está asignado
        if (target == null)
        {
            GameObject foundTarget = GameObject.FindWithTag("Player");

            // Asegurarse de que el objetivo no sea el SpawnPoint
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

        // Ajustar la posición inicial de la cámara
        if (target != null)
        {
            transform.position = new Vector3(
                Mathf.Clamp(target.transform.position.x, izquierdaMax, derechaMax),
                Mathf.Clamp(target.transform.position.y, alturaMin, alturaMax),
                transform.position.z
            );
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

    void Move_Cam()
    {
        if (encendida && target != null)
        {
            Vector3 targetPosition = target.transform.position;

            // Limitar la posición dentro de los límites
            targetPosition.x = Mathf.Clamp(targetPosition.x, izquierdaMax, derechaMax);
            targetPosition.y = Mathf.Clamp(targetPosition.y, alturaMin, alturaMax);
            targetPosition.z = transform.position.z;

            // Suavizar el movimiento de la cámara
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    void Update()
    {
        Move_Cam();
    }
}
