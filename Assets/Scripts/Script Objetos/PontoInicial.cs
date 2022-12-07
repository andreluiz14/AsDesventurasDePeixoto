using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoInicial : MonoBehaviour
{
    [SerializeField] InstanciarObjeto _instanciarObjeto;
    [SerializeField] GameObject _prefabObjeto;
    [SerializeField] BoxCollider2D _boxCollider2D;
    [SerializeField] Vector3 _AreaInteracao;
    private bool _primeiraChamada = true;
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player") && _primeiraChamada)
        {
            _instanciarObjeto.InvocarMetodo();
            _primeiraChamada = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        _boxCollider2D.size = _AreaInteracao;
        Gizmos.DrawCube(transform.position, _AreaInteracao);
    }
}
