using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoVidaObjeto : MonoBehaviour
{
    [SerializeField] float _tempoVidaObjeto;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestruirObjeto");
    }
    IEnumerator DestruirObjeto()
    {
        yield return new WaitForSeconds (_tempoVidaObjeto);
        Destroy(gameObject);
    }
}
