using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetarPosicaoChefe : MonoBehaviour
{
    private bool _jogadorEntrouArea;
    private Vector3 _posicacaoChefe = new Vector3(227,4,0);
    [SerializeField] private Transform _chefe;
    private void Start()
    {
        _chefe = gameObject.GetComponent<Transform>();
    }
    private void Update()
    {
        if(GerenciadorJogador.instance.areaChefe && GerenciadorJogador.instance.estaVivo == false)
        {
          _chefe.position = _posicacaoChefe;
        }
    }
}

