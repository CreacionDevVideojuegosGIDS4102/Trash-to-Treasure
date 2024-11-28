using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLevel1 : MonoBehaviour
{
    public GameObject target; // El jugador que la cámara debe seguir

    private float target_poseX;
    private float posX;

    public float derechaMax = 197.3f; // Límite derecho de la cámara
    public float izquierdaMax = -13.6f; // Límite izquierdo de la cámara

    public float speed = 8f; // Velocidad de la cámara
    public bool encendida = true; // Bandera para activar/desactivar el movimiento de la cámara

    // Start is called before the first frame update
    void Start()
    {
        // Buscar el objeto con la etiqueta "Player"
        target = GameObject.FindGameObjectWithTag("Player");

        if (target == null)
        {
            Debug.LogError("No se encontró el objeto con la etiqueta 'Player'. Verifica si el jugador tiene la etiqueta correcta.");
        }

        // Asegurarnos de que la cámara comienza en la posición del jugador o dentro de los límites
        transform.position = new Vector3(
            Mathf.Clamp(target.transform.position.x, izquierdaMax, derechaMax), 
            transform.position.y, 
            transform.position.z
        );
    }

    // Método para mover la cámara
    void Move_Cam()
    {
        if (encendida && target != null)
        {
            // Obtener la posición X del objetivo (jugador)
            target_poseX = target.transform.position.x;

            // Limitar el movimiento de la cámara en el eje X, pero permitir que se mueva dentro de los límites
            if (target_poseX > izquierdaMax && target_poseX < derechaMax)
            {
                posX = target_poseX; // La cámara sigue al jugador en el eje X
            }
            else if (target_poseX <= izquierdaMax)
            {
                posX = izquierdaMax; // Si el jugador llega al límite izquierdo, la cámara se detiene en ese límite
            }
            else if (target_poseX >= derechaMax)
            {
                posX = derechaMax; // Si el jugador llega al límite derecho, la cámara se detiene en ese límite
            }

            // Suavizar el movimiento de la cámara
            transform.position = Vector3.Lerp(transform.position, new Vector3(posX, transform.position.y, transform.position.z), speed * Time.deltaTime);

            // Debug para ver las posiciones
            Debug.Log("Posición del jugador: " + target_poseX);
            Debug.Log("Posición actual de la cámara: " + transform.position.x);
            Debug.Log("Nueva posición de la cámara: " + posX);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Llamar al método que mueve la cámara
        Move_Cam();
    }
}
