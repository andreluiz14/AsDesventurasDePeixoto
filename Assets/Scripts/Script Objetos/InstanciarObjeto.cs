using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _prefabObjeto;
    [SerializeField] float _atraso, _intervaloSpwan;
    void Start()
    {
    }
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
}
