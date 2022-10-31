using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoFinal : MonoBehaviour
{
    [SerializeField] GameObject _prefabObjeto;
    [SerializeField] Vector3 _tamanhoGizmo;
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            _prefabObjeto.gameObject.SetActive(false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, _tamanhoGizmo);
    }
}
