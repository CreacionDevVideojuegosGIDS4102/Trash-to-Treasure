using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar la escena del juego.

public class CharacterSelectionManager : MonoBehaviour
{
    public GameObject[] characters; // Lista de prefabs de personajes.
    private int selectedCharacterIndex = 0; // Índice del personaje seleccionado.

    // Método para seleccionar un personaje.
    public void SelectCharacter(int index)
    {
        selectedCharacterIndex = index;
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacterIndex); // Guardar la selección.
        Debug.Log("Personaje seleccionado: " + characters[selectedCharacterIndex].name);
    }

    // Método para iniciar el juego con el personaje seleccionado.
    public void StartGame()
    {
        SceneManager.LoadScene("LevelThree"); // Cambiar a la escena principal.
    }
}

