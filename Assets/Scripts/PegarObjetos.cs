using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PegarObjetos : MonoBehaviour
{

    public MoveBox _jogador;
    private HingeJoint2D _objeto;
    private bool _estaPressionado = false;
    [SerializeField] public bool _objetoFixado = false;
    Input_Player _playerInput;
    private void Awake()
    {
        _playerInput = new Input_Player();
    }
    private void Start()
    {
        _objeto = gameObject.GetComponent<HingeJoint2D>();
        _objeto.enabled = false;
    }
    private void OnEnable()
    {
        _playerInput.Enable();
    }
    private void OnDisable()
    {
        _playerInput.Disable();

    }
    public void Interacao(InputAction.CallbackContext context)
    {
        _estaPressionado = context.performed;
    }
    private void OnTriggerStay2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player") && _estaPressionado)
        {
            _objeto.enabled = true;
            _objeto.connectedBody = _jogador.playerRb;
        }
        else
        {
            _objeto.enabled = false;
            //_objeto.connectedBody = null;
        }
    }
    private IEnumerator DelayDaFixacao()
    {
        yield return new WaitForSeconds(8);
        _objetoFixado = true;
    }
}
