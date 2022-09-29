using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public Rigidbody2D playerRb;
    private float _movimentoHorizontal;
    private float _movimentoVertical;
    [SerializeField] private float _playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }
    private void Movimento()
    {
        _movimentoHorizontal = Input.GetAxisRaw("Horizontal");
        _movimentoVertical = Input.GetAxisRaw("Vertical");

        playerRb.AddForce(Vector2.up * _movimentoVertical * _playerSpeed * Time.deltaTime, ForceMode2D.Force);
        playerRb.AddForce(Vector2.right * _movimentoHorizontal * _playerSpeed * Time.deltaTime, ForceMode2D.Force);
    }
}
