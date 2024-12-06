using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenúOpciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    // Métodos para el menú de opciones
    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }
    
    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    // Método para volver al Menú principal
    public void VolverAlMenú()
    {
        SceneManager.LoadScene("Menú"); // Asegúrate de que "Menú" sea el nombre exacto de la escena principal.
    }
}