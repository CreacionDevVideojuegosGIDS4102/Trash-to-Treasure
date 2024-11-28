using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public GameObject[] characters; // Prefabs de los personajes
    public Transform spawnPoint;   // Punto de aparición del personaje
    public FollowLevelThree cameraScript; // Referencia al script de la cámara

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

        // Asigna el personaje instanciado como objetivo de la cámara
        if (cameraScript != null)
        {
            cameraScript.AssignPlayer(playerInstance);
        }
        else
        {
            Debug.LogError("No se encontró el script FollowLevelThree.");
        }
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
                break;

            case "LevelThree":
                playerInstance.AddComponent<MovementControllerLevelThree>();
                Debug.Log("Script asignado: MovementControllerLevelThree.");
                break;

            default:
                Debug.LogWarning("No se han configurado scripts para este nivel.");
                break;
        }

        // Asigna el jugador a la cámara manualmente
        FollowLevelThree cameraFollow = Camera.main.GetComponent<FollowLevelThree>();
        if (cameraFollow != null)
        {
            cameraFollow.AssignPlayer(playerInstance);
        }
        else
        {
            Debug.LogError("No se encontró el script FollowLevelThree en la cámara principal.");
        }
    }
}
