using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player_Character : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private CharacterController controller;
    public float JumpSpeed;
    private float ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
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
        float magnitud = Mathf.Clamp01(movementDirection.magnitude)*speed;
        movementDirection.Normalize();
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && (controller.isGrounded))
        {
            ySpeed = 0;
            ySpeed = JumpSpeed;
        }
        Vector3 velocity = movementDirection * magnitud;
        velocity.y = ySpeed;
        //transform.Translate(movementDirection*speed*Time.deltaTime,Space.World);

        controller.Move(velocity * Time.deltaTime);

        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,toRotation, rotationSpeed* Time.deltaTime);
        }
    }
}
