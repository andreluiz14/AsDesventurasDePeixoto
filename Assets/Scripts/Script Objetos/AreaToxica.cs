using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaToxica : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            print("Player entrou");
        }
    }
    private void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            print("Player saiu");
        }
    }
}
