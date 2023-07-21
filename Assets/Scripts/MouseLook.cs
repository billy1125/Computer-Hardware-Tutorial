using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    public float mouseX;
    public float mouseY;

    public float xRotation = 0f;
    public float yRotation = 0f;

    public Vector2 delta;

    public bool isMoving = false;

    void Start()
    {
        xRotation = transform.localRotation.eulerAngles.x;
        yRotation = transform.localRotation.eulerAngles.y;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            isMoving = true;
    }

    void LateUpdate()
    {
        if (isMoving) { 
            //旋轉身體的視角
            mouseX = Input.GetAxis("Horizontal") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Vertical") * mouseSensitivity * Time.deltaTime;

            if (InputManager.instance.steering.JoystickEnable)
            {
                delta = InputManager.instance.steering.delta;
                mouseX = delta.x * mouseSensitivity * Time.deltaTime;
                mouseY = delta.y * mouseSensitivity * Time.deltaTime;
            }

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, 0.0f, 90.0f); // 左右旋轉限制

            yRotation -= mouseX;
            yRotation = Mathf.Clamp(yRotation, -45.0f, 45.0f); // 上下旋轉限制

            transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);
            //playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    public void EnableMove(bool _move)
    {
        isMoving = _move;
    }

    public void RightArrow()
    {
        mouseX = mouseSensitivity * Time.deltaTime;
    }

    public void LeftArrow()
    {
        mouseX = -mouseSensitivity * Time.deltaTime;
    }
}