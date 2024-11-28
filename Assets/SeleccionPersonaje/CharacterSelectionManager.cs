using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar la carga de escenas.

public class CharacterSelectionManager : MonoBehaviour
{
    public GameObject[] characters; // Lista de prefabs de personajes.
    private int selectedCharacterIndex = 0; // Índice del personaje seleccionado.

    [SerializeField]
    private string defaultLevel = "SelectNivel"; // Cambiado para que el valor predeterminado sea el selector de niveles.

    // Método para seleccionar un personaje.
    public void SelectCharacter(int index)
    {
        selectedCharacterIndex = index;
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacterIndex); // Guardar la selección del personaje.
        Debug.Log("Personaje seleccionado: " + characters[selectedCharacterIndex].name);
    }

    // Método para iniciar el juego con el personaje seleccionado.
    public void StartGame()
    {
        // Comprueba si se ha configurado un nivel desde el Inspector.
        if (string.IsNullOrEmpty(defaultLevel))
        {
            Debug.LogError("No se ha configurado un nivel predeterminado.");
            return;
        }

        SceneManager.LoadScene(defaultLevel); // Cargar el nivel configurado.
        Debug.Log("Cargando escena: " + defaultLevel);
    }

    // Método para cargar la escena de selección de niveles.
    public void LoadLevelSelector()
    {
        SceneManager.LoadScene("SelectNivel"); // Cargar la escena del selector de niveles.
        Debug.Log("Cargando escena: SelectNivel");
    }
}
