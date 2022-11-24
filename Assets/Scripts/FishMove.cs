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

        if(GerenciadorJogador.instance.estaVivo == true)
        {
            Vector2 direcao = new Vector2(horizontal, vertical);
            this.rbJogador.velocity = direcao * this.velocidadeMov;
        }

        
        if (GerenciadorObjetos.instance.estaComObjeto == false)
        {
            float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;
            Vector3 newRotation = new Vector3(0, 0, angle);
            if (horizontal < 0)
                newRotation = new Vector3(180, 0, -1*angle);
            transform.eulerAngles = newRotation;
           
        }

    }


    
}
