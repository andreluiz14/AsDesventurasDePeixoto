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
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (GerenciadorJogador.instance.estaVivo == false) { 
            rbJogador.velocity = Vector3.zero;
            KillPlayer();
        }

        //Debug.Log(GerenciadorObjetos.instance.estaComObjeto);

        if (GerenciadorJogador.instance.estaVivo == true)
        {
            MovePlayerAin();
            Vector2 direcao = new Vector2(horizontal, vertical);
            //this.rbJogador.velocity = direcao * this.velocidadeMov;
            this.rbJogador.velocity = direcao * this.velocidadeMov * Time.deltaTime;


            if (GerenciadorObjetos.instance.estaComObjeto == false)
            {
                float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;
                Vector3 newRotation = new Vector3(0, 0, angle);
                if (horizontal < 0)
                    newRotation = new Vector3(180, 0, -1 * angle);
                transform.eulerAngles = newRotation;
            }
        }
    }

    public void KillPlayer()
    {
        animator.SetTrigger("killPlayer");
        Debug.Log("Morreu");
    }
    public void MovePlayerAin()
    {
        animator.SetTrigger("MovePlayer");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Boost")
        {
            velocidadeMov = 950;
        }
    }
}
