﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;

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
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= movementSpeed;
            rotation = new Vector3(moveDirection.x, 0f, moveDirection.z);
        }

        if (rotation != Vector3.zero)
        {
            transform.forward = rotation;
        }

        moveDirection.y -= 20.0f * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
