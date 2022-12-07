using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ_Ventilador : MonoBehaviour
{
    [SerializeField] private GameObject _ventiladorParado;
    [SerializeField] private GameObject _ventiladorGrade;
    [SerializeField] private Effector2D _effector2D;
    private HingeJoint2D _hJoint2D;
    private JointMotor2D _jointMotor2D;
    private void Start()
    {
        _hJoint2D = gameObject.GetComponent<HingeJoint2D>();
        _jointMotor2D = _hJoint2D.motor;
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player") )
        {
            GerenciadorJogador.instance.estaVivo = false;

        }else if (outro.gameObject.CompareTag("Caixa"))
        {
            PararMotor();
            TrocarSprite();
            DesativartEffector();
            GerenciadorObjetos.instance.estaComObjeto = false;
            outro.gameObject.SetActive(false);
        }
    }
    private void PararMotor()
    {
        _jointMotor2D.motorSpeed = 0;
        _hJoint2D.motor = _jointMotor2D;
    }
    private void DesativartEffector()
    {
        _effector2D.enabled = false;
    }
    private void TrocarSprite()
    {
        _ventiladorGrade.SetActive(false);
        _ventiladorParado.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
