/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public MonoBehaviour playerController; // Usamos MonoBehaviour para que pueda funcionar con cualquier controlador del jugador
    public Image meterImage;
    public Text hpText;

    void Start()
    {
        if (playerController == null)
        {
            Debug.LogError("playerController no está asignado en HealthBar.");
        }

        UpdateHealthBar();
    }

    void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (playerController != null)
        {
            // Si el jugador tiene una propiedad 'playerLife' para la vida, actualizamos la barra de salud
            var lifeProperty = playerController.GetType().GetProperty("playerLife");
            if (lifeProperty != null)
            {
                float playerLife = (float)lifeProperty.GetValue(playerController);
                meterImage.fillAmount = playerLife / 100f;
                hpText.text = "HP: " + playerLife;
            }
        }
        else
        {
            Debug.LogError("playerController no asignado en HealthBar.");
        }
    }
}
*/