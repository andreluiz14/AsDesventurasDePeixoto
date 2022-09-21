using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{

    public Animator animator;
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float velocidadeMov;



   

    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator anim = GetComponent<Animator>(); 
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direcao = new Vector2(horizontal, vertical);
        this.rb.velocity = direcao * this.velocidadeMov;

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
        animator.SetFloat("Speed", direcao.sqrMagnitude);

    }
}
