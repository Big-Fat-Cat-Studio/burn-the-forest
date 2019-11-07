using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float jumpStrength = 10.0f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));
        moveDirection.x *= movementSpeed;
        moveDirection.z *= movementSpeed;

        if (characterController.isGrounded)
        {
            moveDirection.y = 0;
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpStrength;
            }
        }
        
        rotation = new Vector3(moveDirection.x, 0f, moveDirection.z);

        if (rotation != Vector3.zero)
        {
            transform.forward = rotation;
        }

        moveDirection.y -= 20.0f * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
