using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoFinal : MonoBehaviour
{
    [SerializeField] GameObject _prefabObjeto;
    [SerializeField] InstanciarObjeto _instanciarObjeto;
    [SerializeField] BoxCollider2D _boxCollider2D;
    [SerializeField] Vector3 _AreaInteracao;
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            _instanciarObjeto.CancelarMetodo();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        _boxCollider2D.size = _AreaInteracao;
        Gizmos.DrawCube(transform.position, _AreaInteracao);
    }
}
