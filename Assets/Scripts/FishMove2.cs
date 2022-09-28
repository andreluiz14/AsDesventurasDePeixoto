using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove2 : MonoBehaviour
{
    [Header("Fish settings")]
    public float driftFactor = 0.95f;
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;

    float accelarationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    Rigidbody2D fishRigidbody2D;

    void Awake()
    {
        fishRigidbody2D = GetComponent<Rigidbody2D>(); 

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        ApplyEngineForce();

        ApplySteering();

        KillOrthogonalVelocity();
    }
    void ApplyEngineForce()
    {
        Vector2 engineForceVector = transform.up * accelarationInput * accelerationFactor;

        fishRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);

    }
    void ApplySteering()
    {
        rotationAngle -= steeringInput * turnFactor;

        fishRigidbody2D.MoveRotation(rotationAngle);
    }
    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(fishRigidbody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(fishRigidbody2D.velocity, transform.right);

        fishRigidbody2D.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelarationInput = inputVector.y;
    }
}
