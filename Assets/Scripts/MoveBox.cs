using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public Rigidbody2D jogadorRb;
    private float _movimentoHorizontal;
    private float _movimentoVertical;
    [SerializeField] private float _playerSpeed;
    public bool aa;
    // Start is called before the first frame update
    void Start()
    {
        jogadorRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        if (Input.GetMouseButtonDown(0))
        {
            aa = !aa;
        }
    }
    private void Movimento()
    {
        _movimentoHorizontal = Input.GetAxisRaw("Horizontal");
        _movimentoVertical = Input.GetAxisRaw("Vertical");

        jogadorRb.AddForce(Vector2.up * _movimentoVertical * _playerSpeed * Time.deltaTime, ForceMode2D.Force);
        jogadorRb.AddForce(Vector2.right * _movimentoHorizontal * _playerSpeed * Time.deltaTime, ForceMode2D.Force);
    }
}
