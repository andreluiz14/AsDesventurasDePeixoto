using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorObjetos : MonoBehaviour
{
    public static GerenciadorObjetos instance;
    public bool estaComObjeto;
    private void Awake()
    {
        instance = this;
    }
}
