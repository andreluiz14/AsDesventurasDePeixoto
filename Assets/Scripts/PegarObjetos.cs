using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarObjetos : MonoBehaviour
{
    MoveBox jogador;
    private FixedJoint2D objeto;
    private void Start()
    {
        objeto = gameObject.GetComponent<FixedJoint2D>();
    }
    private void OnTriggerStay2D(Collider2D outro)
    {
        if (outro.CompareTag("Player") && Input.GetKey(KeyCode.Space))
        {
            print("Colidiu");
            //jogador.playerRb = jogador.GetComponent<Rigidbody2D>();
            objeto.connectedBody = jogador.playerRb;
        }
    }
}
