using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollow : MonoBehaviour
{
    Rigidbody2D rb;
    //Vector3 posicaoBoss;
    
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        rb.velocity = Vector3.right * speed * Time.deltaTime;
        //rb.MovePosition(Vector2.right * speed * Time.deltaTime);
    }
}
