using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    Rigidbody MyRigidbody;
    Vector3 Velocity;


    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Vector3 keyInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 forward = keyInput.normalized;

        Velocity = forward * 10f;
    }


    void FixedUpdate()
    {
        MyRigidbody.position += Velocity * Time.fixedDeltaTime;

    }
}