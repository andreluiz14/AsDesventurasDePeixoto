using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorJogador : MonoBehaviour
{
    public static GerenciadorJogador instance;
    public bool estaVivo;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
