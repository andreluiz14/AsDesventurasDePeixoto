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
        GerenciadorJogador.instance.estaVivo = true;
        rbJogador = GetComponent<Rigidbody2D>();
        Animator anim = GetComponent<Animator>(); 
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direcao = new Vector2(horizontal, vertical);
        this.rbJogador.velocity = direcao * this.velocidadeMov;

        // Esses paramentros não exitem
        /*
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
        animator.SetFloat("Speed", direcao.sqrMagnitude);
        */
        if (GerenciadorObjetos.instance.estaComObjeto == false)
        {
            if (vertical > 0)
            {
                Vector3 newRotation = new Vector3(0, 0, -90);
                transform.eulerAngles = newRotation;
            }
            if (vertical < 0)
            {
                Vector3 newRotation = new Vector3(0, 0, 90);
                transform.eulerAngles = newRotation;
            }
            if (horizontal > 0)
            {
                Vector3 newRotation = new Vector3(0, 180, 0);
                transform.eulerAngles = newRotation;
            }
            if (horizontal < 0)
            {
                Vector3 newRotation = new Vector3(0, 0, 0);
                transform.eulerAngles = newRotation;
            }
        }

    }


    
}
