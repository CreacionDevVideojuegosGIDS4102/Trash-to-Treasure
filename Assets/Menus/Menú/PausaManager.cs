using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaManager : MonoBehaviour
{

    public GameObject cuadroPausa;
    public bool enPausa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PausarBoton()
    {
        enPausa = true;
        cuadroPausa.SetActive(true);   
        Time.timeScale = 0.1f;
    }

    public void continuar()
    {
        enPausa=false;
        cuadroPausa.SetActive(false);
        Time.timeScale = 1f;
    }
}
