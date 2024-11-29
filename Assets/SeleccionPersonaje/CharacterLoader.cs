using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public GameObject[] characters; // Prefabs de los personajes
    public Transform spawnPoint;   // Punto de aparición del personaje

    private GameObject playerInstance; // Referencia al personaje instanciado

    void Start()
    {
        LoadCharacter();
        AssignScripts();
    }

    void LoadCharacter()
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0); // Recupera el índice del personaje
        if (selectedCharacterIndex < 0 || selectedCharacterIndex >= characters.Length)
        {
            Debug.LogError("Índice de personaje inválido.");
            return;
        }

        // Instancia el personaje seleccionado
        playerInstance = Instantiate(characters[selectedCharacterIndex], spawnPoint.position, Quaternion.identity);
        playerInstance.name = "Player"; // Asegura que el objeto instanciado se llame Player
        playerInstance.tag = "Player";
    }

    void AssignScripts()
    {
        if (playerInstance == null)
        {
            Debug.LogError("El personaje no fue instanciado correctamente.");
            return;
        }

        Debug.Log("Asignando scripts al personaje instanciado: " + playerInstance.name);

        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        switch (currentSceneName)
        {
            case "LevelOne":
                playerInstance.AddComponent<MovementControllerLevel1>();
                Debug.Log("Script asignado: MovementControllerLevel1.");

                // Asigna el script FollowLevelOne a la cámara
                FollowLevelOne cameraFollowOne = Camera.main.GetComponent<FollowLevelOne>();
                if (cameraFollowOne != null)
                {
                    cameraFollowOne.AssignPlayer(playerInstance);
                }
                else
                {
                    Debug.LogError("No se encontró el script FollowLevelOne en la cámara principal.");
                }
                break;

            case "LevelTwo":
                playerInstance.AddComponent<MovementController>();
                Debug.Log("Script asignado: MovementController.");

                Follow cameraFollow = Camera.main.GetComponent<Follow>();
                if (cameraFollow != null)
                {
                    cameraFollow.SetLevelSpecificBehavior("LevelTwo");
                    cameraFollow.AssignPlayer(playerInstance);
                }
                else
                {
                    Debug.LogError("No se encontró el script Follow en la cámara principal.");
                }
                break;

            case "LevelThree":
                playerInstance.AddComponent<MovementControllerLevelThree>();
                Debug.Log("Script asignado: MovementControllerLevelThree.");

                // Asigna el script FollowLevelThree a la cámara
                FollowLevelThree cameraFollowThree = Camera.main.GetComponent<FollowLevelThree>();
                if (cameraFollowThree != null)
                {
                    cameraFollowThree.AssignPlayer(playerInstance);
                }
                else
                {
                    Debug.LogError("No se encontró el script FollowLevelThree en la cámara principal.");
                }
                break;

            default:
                Debug.LogWarning("No se han configurado scripts para este nivel.");
                break;
        }
    }
}
