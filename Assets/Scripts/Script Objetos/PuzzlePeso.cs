using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePeso : MonoBehaviour
{

    private int _qtd;
    private HingeJoint2D _objetoHJ;
    [SerializeField] float _tempoDesativarObjeto;
    [SerializeField] GameObject[] _objetoPuzzle;

    private void Start()
    {
        _objetoHJ = gameObject.GetComponent<HingeJoint2D>();
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Caixa"))
        {
            _qtd++;
            print(_qtd);
        }
        if (_qtd == 3)
        {
            _objetoHJ.enabled = false;
            StartCoroutine("DesabilitarObjeto");
        }
    }
    private void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Caixa"))
        {
            _qtd--;
            print(_qtd);
        }
    }
    private IEnumerator DesabilitarObjeto()
    {
        yield return new WaitForSeconds(_tempoDesativarObjeto);
        foreach (var todoItens in _objetoPuzzle)
        {
            todoItens.gameObject.SetActive(false);
        }
    }
}
