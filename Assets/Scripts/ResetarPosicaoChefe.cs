using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetarPosicaoChefe : MonoBehaviour
{
    private bool _jogadorEntrouArea;
    [SerializeField] private GameObject _jogador;
    [SerializeField] private GameObject _chefe;
    private Vector3 _posicao = new Vector3(-187.85f, 0.07f, 0);
    private void Start()
    {
    }
    private void Update()
    {
        if(_jogadorEntrouArea && GerenciadorJogador.instance.estaVivo == false)
        {
            ResetarPosicao();
        }
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            _jogadorEntrouArea = true;
        }
    }
    private void ResetarPosicao()
    {
        _chefe.transform.position = transform.position;
    }
}

