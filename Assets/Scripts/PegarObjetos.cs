using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarObjetos : MonoBehaviour
{
    public MoveBox _jogador;
    private HingeJoint2D _objeto;
    public bool teste;
    [SerializeField] private bool _objetoFixado = false;
    private void Start()
    {
        _objeto = gameObject.GetComponent<HingeJoint2D>();
        _objeto.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            teste = true;
        }
        if (_objetoFixado)
        {
            _objeto.connectedBody = _jogador.playerRb;
            _objeto.enabled = true;
        }
    }
    private void OnTriggerStay2D(Collider2D outro)
    {
        if (outro.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            _objetoFixado = !_objetoFixado;
        }
    }
    private IEnumerator DelayDaFixacao()
    {
        yield return new WaitForSeconds(8);
        _objetoFixado = true;
    }
}
