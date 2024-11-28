/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptAssigner : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (player != null)
        {
            AssignScriptsForLevel();
        }
        else
        {
            Debug.LogError("Player no encontrado.");
        }
    }

    void AssignScriptsForLevel()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // Remover scripts previos si existen
        var existingScripts = player.GetComponents<MonoBehaviour>();
        foreach (var script in existingScripts)
        {
            Destroy(script);
        }

        // Asignar scripts según el nivel
        if (currentScene == "LevelOne")
        {
            player.AddComponent<MovementControllerLevel1>();
            player.AddComponent<WasteControllerLevel1>();
        }
        else if (currentScene == "LevelThree")
        {
            player.AddComponent<MovementControllerLevelThree>();
            player.AddComponent<WasteControllerLevelThree>();
        }
        else
        {
            Debug.LogWarning("No se definieron scripts para esta escena.");
        }
    }
}
*/