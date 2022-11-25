using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform playerPos;
    private Vector3 checkPointPos;

    private void Start()
    {
        playerPos = gameObject.GetComponent<Transform>();
    }
    private void Update()
    {
        //print(checkPointPos);
        if(GerenciadorJogador.instance.estaVivo == false)
        {
            StartCoroutine("TempoRetorno");
        }
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Respawn"))
        {
            checkPointPos = playerPos.position;
        }
    }
    IEnumerator TempoRetorno()
    {
       yield return new WaitForSeconds(4f);
            RetomarPosicaoJogador();
    }
    private void RetomarPosicaoJogador()
    {
        playerPos.position = checkPointPos;
        GerenciadorJogador.instance.estaVivo = true;
    }
}
