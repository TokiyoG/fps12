using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoverment : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float JumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject Gun;
    public Animator animator;
    Vector3 velocity;
    bool isGrounded;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }



        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse0))

        {

            animator.SetInteger("WeaponType_int", 1);

            animator.SetBool("Shoot_b", true);

            Gun.GetComponent<SimpleShoot>().pullTrigger();
        }


        else if (Input.GetKeyUp(KeyCode.Mouse0))

        {

            animator.SetInteger("WeaponType_int", 0);

            animator.SetBool("Shoot_b", false);

        }

            animator.SetFloat("Speed_f", move.magnitude);
        }

    }

