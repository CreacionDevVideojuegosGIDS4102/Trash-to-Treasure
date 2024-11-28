/*using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar escenas

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    public int currentLevel = 1;
    public int organicWasteToNextLevel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Asegura que solo haya una instancia de LevelController
        }
    }

    void Start()
    {
        SetLevelGoal(currentLevel); // Establece la meta al iniciar el juego
    }

    // Establecer la meta según el nivel
    public void SetLevelGoal(int level)
    {
        switch (level)
        {
            case 1:
                organicWasteToNextLevel = 30;
                break;
            case 2:
                organicWasteToNextLevel = 45;
                break;
            case 3:
                organicWasteToNextLevel = 60;
                break;
            default:
                organicWasteToNextLevel = 30;
                break;
        }
    }

    // Avanzar al siguiente nivel
    public void AdvanceToNextLevel()
    {
        currentLevel++;

        // Actualizar meta para el siguiente nivel
        SetLevelGoal(currentLevel);

        // Cambiar de escena para el siguiente nivel
        LoadNextLevel();
    }

    // Cargar la siguiente escena
    private void LoadNextLevel()
    {
        string nextSceneName = "Level" + currentLevel;

        // Verificar si la escena existe en Build Settings
        if (IsSceneInBuildSettings(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("Nivel no encontrado en Build Settings: " + nextSceneName);
        }
    }

    // Método para comprobar si la escena está en Build Settings
    private bool IsSceneInBuildSettings(string sceneName)
    {
        // Itera por todas las escenas en Build Settings
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            if (scenePath.Contains(sceneName))
            {
                return true;
            }
        }
        return false;
    }
}*/
