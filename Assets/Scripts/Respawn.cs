using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Transform spwanPoint;
    public Transform playerPos;

    void Start()
    {
        playerPos = gameObject.GetComponent<Transform>();
    }
    private void Update()
    {
        if(GerenciadorJogador.instance.estaVivo == false)
        {
            gameObject.transform.position = spwanPoint.position;

            print(spwanPoint.position);
        }
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Respawn"))
        {

            spwanPoint = gameObject.GetComponent<Transform>();
            spwanPoint.position = gameObject.transform.position;

        }
    }
    
}
