using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorNiveles : MonoBehaviour
{
    public static ControladorNiveles instancia;
    public Button[] botonesNiveles; // Botones de niveles
    public int desbloquearNiveles;  // Nivel a desbloquear

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
    }

    void Start()
    {
        if (botonesNiveles.Length > 0) // Corregido: Length en lugar de Lenght
        {
            // Desactiva todos los botones inicialmente
            for (int i = 0; i < botonesNiveles.Length; i++)
            {
                botonesNiveles[i].interactable = false;
            }

            // Activa los botones desbloqueados
            for (int i = 0; i < PlayerPrefs.GetInt("nivelesDesbloqueados", 1); i++) // Corregido: PlayerPrefs en lugar de PlayerPrefers
            {
                if (i < botonesNiveles.Length) // Verifica que no se salga del rango
                {
                    botonesNiveles[i].interactable = true;
                }
            }
        }
    }

    public void AumentarNiveles()
    {
        // Comprueba si se debe actualizar el número de niveles desbloqueados
        if (desbloquearNiveles > PlayerPrefs.GetInt("nivelesDesbloqueados", 1)) // Corregido: PlayerPrefs en lugar de playerPrefs
        {
            PlayerPrefs.SetInt("nivelesDesbloqueados", desbloquearNiveles);
            PlayerPrefs.Save(); // Asegura que los datos se guarden
        }
    }
}
