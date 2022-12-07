using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    
    public void CarregarCena()
    {
        SceneManager.LoadScene("Fase_1");
    }
    public void FecharJogo()
    {
        Application.Quit();
    }
}
