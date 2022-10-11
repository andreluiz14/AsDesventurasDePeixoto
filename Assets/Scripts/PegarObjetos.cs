using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarObjetos : MonoBehaviour
{
    [SerializeField] KeyCode _pegarObjeto;
    [SerializeField] KeyCode _soltarObjeto;
    [SerializeField] Rigidbody2D _objetoRb;
    public MoveBox _jogador;
    private HingeJoint2D _objeto;
    private void Start()
    {
        _objeto = gameObject.GetComponent<HingeJoint2D>();
        _objeto.enabled = false;
    }
    private void Update()
    {

        if (Input.GetKey(_soltarObjeto))
        {
            _objeto.enabled = false;
            _objeto.connectedBody = null;
        }
    }
    private void OnTriggerStay2D(Collider2D outro)
    {
        if(outro.gameObject.CompareTag("Player") && Input.GetKey(_pegarObjeto))
        {
            _objeto.enabled = true;
            _objeto.connectedBody = _jogador.jogadorRb;
            _objetoRb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
