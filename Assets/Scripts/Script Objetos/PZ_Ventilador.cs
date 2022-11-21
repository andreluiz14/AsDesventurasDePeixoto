using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ_Ventilador : MonoBehaviour
{
    private HingeJoint2D _hJoint2D;
    private JointMotor2D _jointMotor2D;
    private void Start()
    {
        _hJoint2D = gameObject.GetComponent<HingeJoint2D>();
        _jointMotor2D = _hJoint2D.motor;
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player") || outro.gameObject.CompareTag("Caixa"))
        {
            PararMotor();
        }
    }
    private void PararMotor()
    {
        _jointMotor2D.motorSpeed = 0;
        _hJoint2D.motor = _jointMotor2D;
    }
}
