using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ_AreaAtracao : MonoBehaviour
{
    [SerializeField] BoxCollider2D _boxCollider2D;
    [SerializeField] Vector3 _AreaInteracao;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Color color = Color.red;
        color.a = 0.25f;
        Gizmos.color = color;
        _boxCollider2D.size = _AreaInteracao;
        Gizmos.DrawCube(transform.position, _AreaInteracao);
    }
}
