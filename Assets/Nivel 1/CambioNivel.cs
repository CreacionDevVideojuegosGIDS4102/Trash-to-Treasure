using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("boton cambiar nivel")]
    public void CambiarNivel()
    {
        int nivelActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nivelActual + 1);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Tocando algo");

        if(collision.gameObject.tag == "Cambio")
        {
            Debug.Log("Tocando Cambio");

            int nivelActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(nivelActual + 1);
        }
    }
}