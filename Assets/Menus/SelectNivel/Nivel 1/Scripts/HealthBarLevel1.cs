using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarLevel1 : MonoBehaviour
{
    public MovementControllerLevel1 playerController; 
    public Image meterImage; 
    public Text hpText; // Texto de HP en la barra

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
            // Actualizar la barra de salud
            meterImage.fillAmount = playerController.playerLife / 100f;
            hpText.text = "HP: " + playerController.playerLife; // Muestra la vida actual
        }
        else
        {
            Debug.LogError("playerController no asignado en HealthBar.");
        }
    }
}
