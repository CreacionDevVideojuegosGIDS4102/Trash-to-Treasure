using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BotonStart()
    {

        SceneManager.LoadScene(1);

    }
    // Método para ir a la escena de Opciones
    public void BotonOpciones()
    {
        SceneManager.LoadScene(2); // Índice de la escena de Opciones
    }

    public void BotonSalir()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
