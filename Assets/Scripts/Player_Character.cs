using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player_Character : MonoBehaviour
{
    public float maxSpeed;
    public float rotationSpeed;
    private CharacterController controller;
    public float JumpSpeed;
    private float ySpeed;
    private Animator animator;
    public Transform TransformCamera;
    private float originalSetOffset;
    private bool isJumping;
    private bool isGrounded;
    private float jumpHorizontalSped;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        originalSetOffset = controller.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float v = Mathf.Clamp01(movementDirection.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            v /= 0.5f;
        }

        animator.SetFloat("InputMagnitude", v, 0.5f, Time.deltaTime);
        float speed = v * maxSpeed;
        movementDirection = Quaternion.AngleAxis(TransformCamera.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded)
        {
            controller.stepOffset = originalSetOffset;
            ySpeed = -0.5f;
            animator.SetBool("IsGrounded", true);
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            isJumping = false;
            animator.SetBool("IsFalling", false);
            
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = JumpSpeed;
                animator.SetBool("IsJumping", true);
                isJumping = true;
            }
            
        }
        else
        {
            animator.SetBool("IsGrounded", false);
            isGrounded = false;
            if((isJumping && ySpeed < 0) || ySpeed< -2 )
            {
                animator.SetBool("IsFalling", true);
            }

        }
        Vector3 velocity = movementDirection * speed;
        velocity.y = ySpeed;
        //transform.Translate(movementDirection*speed*Time.deltaTime,Space.World);

        controller.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if(isGrounded == false)
        {
            Vector3 velocidad = movementDirection * jumpHorizontalSped;
            velocidad.y = ySpeed;
            controller.Move(velocidad * Time.deltaTime);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
