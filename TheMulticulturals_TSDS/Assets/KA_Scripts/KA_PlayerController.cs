using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KA_PlayerController : MonoBehaviour
{
    public float speed = 8.0f;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    float Timer;
    float dodge_time = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer * Time.time;
        Debug.Log(Timer);

        // Controller Variables
        float rStickX = Input.GetAxis("X360_RStickX");
        float rStickY = Input.GetAxis("X360_RStickY");

        {
            CharacterController controller = GetComponent<CharacterController>();
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if (Input.GetButtonDown("X360_A"))
                    moveDirection.y = jumpSpeed;

            }

            if (Input.GetButtonDown("X360_LStickClick"))
            {
                speed = speed * 2f;
            }

            else if (Input.GetButtonUp("X360_LStickClick"))
            {
                speed = 8.0f;
            }

            if (Input.GetButtonDown("X360_B"))
            {                
                if (Timer < dodge_time)
                {
                    Evade();
                    Timer = 0;
                }
                if (Timer > dodge_time)
                {
                    speed = 8.0f;
                }                
            }
            else if (Input.GetButtonUp("X360_B") && Timer > dodge_time)
            {
                speed = 8.0f;
            }

            if (Input.GetButtonDown("X360_B") && Timer > dodge_time)
            {
                Timer = 1;
            }

            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);

            yaw += speedH * rStickX;
            //pitch -= speedV * rStickY;

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        }

        
    }

    void Evade ()
    {
        speed = speed * 4.0f;
        Timer = 0;
    }
}
