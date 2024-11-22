using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
