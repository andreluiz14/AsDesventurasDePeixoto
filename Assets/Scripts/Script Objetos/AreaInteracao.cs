using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaInteracao : MonoBehaviour
{
    [SerializeField] BoxCollider2D _boxCollider2D;
    [SerializeField] Vector3 _AreaInteracao;
    [SerializeField] Color colorSelect;

    private void OnDrawGizmos()
    {
        Gizmos.color = colorSelect;
        Color color = colorSelect;
        color.a = 0.25f;
        Gizmos.color = color;
        _boxCollider2D.size = _AreaInteracao;
        Gizmos.DrawCube(transform.position, _AreaInteracao);
    }
}
