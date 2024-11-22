/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntuacionManager : MonoBehaviour
{
    // (Código existente)

    public void GuardarPuntuacion()
    {
        int puntuacionMaxima = PlayerPrefs.GetInt("MejorPuntuacion", 0);
        if (puntuacionActual > puntuacionMaxima)
        {
            PlayerPrefs.SetInt("MejorPuntuacion", puntuacionActual);
        }

        // Agregar la puntuación al ranking
        for (int i = 1; i <= 5; i++)
        {
            if (puntuacionActual > PlayerPrefs.GetInt($"Ranking{i}", 0))
            {
                for (int j = 5; j > i; j--)
                {
                    PlayerPrefs.SetInt($"Ranking{j}", PlayerPrefs.GetInt($"Ranking{j - 1}", 0));
                }
                PlayerPrefs.SetInt($"Ranking{i}", puntuacionActual);
                break;
            }
        }

        PlayerPrefs.Save();
    }
}
*/