using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _prefabObjeto;
    private Vector3 _tamanhoGizmo = new Vector3(1,1,0);
    [SerializeField] float _atraso, _intervaloSpwan;
    private void InstanciarObjetos()
    {
        Instantiate(_prefabObjeto, gameObject.transform.position, Quaternion.identity);
    }
    private IEnumerator TempoInstanciar()
    {
        yield return new WaitForSeconds(4);
        InstanciarObjetos();
    }
    public void InvocarMetodo()
    {
        InvokeRepeating("InstanciarObjetos", _atraso, _intervaloSpwan);
    }
    public void CancelarMetodo()
    {
        CancelInvoke("InstanciarObjetos");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, _tamanhoGizmo);
    }
}
