using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{

    public Animator animator;
    [SerializeField]
    public Rigidbody2D rbJogador;

    [SerializeField]
    private float velocidadeMov;

    private SpriteRenderer sprite;
    // Update is called once per frame

    private void Start()
    {
        rbJogador = GetComponent<Rigidbody2D>();
        Animator anim = GetComponent<Animator>(); 
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Movimentacao();
    }

    private void Flip(float horizontal)
    {
        if (!GerenciadorObjetos.instance.estaComObjeto)
        {
            if(horizontal > 0)
            {
                sprite.flipX = false;
            }
            else if (horizontal < 0)
            {
                sprite.flipX = true;
            }
        }
    }
    private void Movimentacao()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direcao = new Vector2(horizontal, vertical);
        this.rbJogador.velocity = direcao * this.velocidadeMov;

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
        animator.SetFloat("Speed", direcao.sqrMagnitude);
        Flip(horizontal);
    }
}
