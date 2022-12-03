using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] private TMP_Text _textoMorte;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ApresentarTelaMorte();
    }
    private void ApresentarTelaMorte()
    {
        if(GerenciadorJogador.instance.estaVivo == false)
        {
            _textoMorte.enabled = true;
        }
        else
        {
            _textoMorte.enabled = false;
        }
    }
}
