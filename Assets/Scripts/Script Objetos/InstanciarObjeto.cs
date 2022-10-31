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
        InvokeRepeating("InstaciarObjeto", _atraso, _intervaloSpwan);
    }
    private void InstaciarObjeto()
    {
        Instantiate(_prefabObjeto, gameObject.transform.position, Quaternion.identity);
    }
    private IEnumerator TempoInstaciar()
    {
        yield return new WaitForSeconds(4);
        InstaciarObjeto();
    }
}
