using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorJogador : MonoBehaviour
{
    public static GerenciadorJogador instance;
    public bool estaVivo;
    private void Awake()
    {
        instance = this;
    }
}
