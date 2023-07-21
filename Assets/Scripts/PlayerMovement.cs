using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody PlayerRig;
    public float speed = 12f;//移動速度
    public float gravity = -9.81f;//重力

    public Transform groundCheck;
    public float grounDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public bool isMove = false;

    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, grounDistance, groundMask);

        //if (isGrounded && velocity.y < 0)
        //{
        //    velocity.y = -2f;
        //}

        if (isMove) { 
            float x = Input.GetAxis("Horizontal");//input水平
            float z = Input.GetAxis("Vertical");//input垂直

            Vector3 move = transform.right * x + transform.forward * z;

            //print(move);

            controller.Move(move * speed * Time.deltaTime);
        }
        else
        {
            controller.Move(Vector3.zero * speed * Time.deltaTime);
        }

        //velocity.y += gravity * Time.deltaTime;

        //controller.Move(velocity * Time.deltaTime);

        //PlayerRig.AddForce(move * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
            if (isMove)
                isMove = false;
            else
                isMove = true;

    }
}