using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoInicial : MonoBehaviour
{
    [SerializeField] GameObject _prefabObjeto;
    [SerializeField] Vector3 _tamanhoGizmo;
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            _prefabObjeto.gameObject.SetActive(true);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, _tamanhoGizmo);
    }
}
