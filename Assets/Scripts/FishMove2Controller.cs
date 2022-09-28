using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove2Controller : MonoBehaviour
{
    FishMove2 fishmovecontroller;

    // Start is called before the first frame update
    void Awake()
    {
        fishmovecontroller = GetComponent<FishMove2>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        fishmovecontroller.SetInputVector(inputVector);

    }
}
