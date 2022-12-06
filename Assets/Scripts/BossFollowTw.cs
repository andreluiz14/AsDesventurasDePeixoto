using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollowTw : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;

    [SerializeField]
    private float velocidadeMovimento;

    [SerializeField]
    private Rigidbody2D rigidbody;


    [SerializeField]
    private Animator animator;


    [SerializeField]
    private float distanciaMinima;

    [SerializeField]
    private float raioVisao;

    [SerializeField]
    private LayerMask layerAreaVisao;

    [SerializeField]
    private float raioVisaoAnim;






    // Update is called once per frame
    private void Update()
    {
        ProcurarJogador();


        AbreBoca();


    }
    private void FixedUpdate()
    {
        if (this.alvo != null)
        {
            Mover();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.raioVisao);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.raioVisaoAnim);

    }

    private void ProcurarJogador()
    {
       Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisao, this.layerAreaVisao);
        if(colisor != null)
        {
            this.alvo = colisor.transform;
        }
    }

    private void AbreBoca()
    {
        Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisaoAnim, this.layerAreaVisao);
        if(colisor != null)
        {
            animator.SetBool("morder", true);
        }
        else
        {
            animator.SetBool("morder", false);
        }
    }


    private void Mover()
    {
        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;

        float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
        if (distancia >= this.distanciaMinima)
        {
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;

            this.rigidbody.velocity = (this.velocidadeMovimento * direcao * Time.fixedDeltaTime);


        }
    }

   

    

}
