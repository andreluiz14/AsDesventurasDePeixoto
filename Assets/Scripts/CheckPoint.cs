using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform playerPos;
    private Vector3 checkPointPos;
    private bool _emCheckPoint;
    [SerializeField] private float _tempoDeEspera;

    private void Start()
    {
        playerPos = gameObject.GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        //print(checkPointPos);
        if(GerenciadorJogador.instance.estaVivo == false && !_emCheckPoint)
        {
            //RetomarPosicaoJogador();
            StartCoroutine("TempoRetorno");
            _emCheckPoint = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Respawn"))
        {
            SalvaPosicaoJogador();
        }
    }
    IEnumerator TempoRetorno()
    {
        print("Teste");
        yield return new WaitForSeconds(_tempoDeEspera);
        RetomarPosicaoJogador();
    }
    private void RetomarPosicaoJogador()
    {
        playerPos.position = checkPointPos;
        GerenciadorJogador.instance.estaVivo = true;
        _emCheckPoint = false;
    }
    private void SalvaPosicaoJogador()
    {
        checkPointPos = playerPos.position;
    }
}
