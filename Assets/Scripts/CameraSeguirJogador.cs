using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguirJogador : MonoBehaviour
{
    private Camera size;
    [SerializeField] Transform _jogador;
    public Vector3 deslocamento;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
  
        transform.position = _jogador.transform.position + new Vector3(0,0, -10);
    }
}
