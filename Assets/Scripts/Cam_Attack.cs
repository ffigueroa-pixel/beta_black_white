using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Cam_Attack : MonoBehaviour
{
    Animator anim;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject arma;
    public GameObject croshair;
    public float speed;
    public float speedRot;
    public GameObject PlayerFPS;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivateCamera();
    }

    void ActivateCamera()
    {
        if (Input.GetButton("Fire2"))
        {
            anim.SetBool("Aiming", true);
            cam1.SetActive(false);
            cam2.SetActive(true);
            arma.SetActive(true);
            croshair.SetActive(true);
            MovimientoFPS();
            PlayerFPS.GetComponent<Player_Character>().enabled = false;
        }
        else
        {
            anim.SetBool("Aiming", false);
            cam1.SetActive(true);
            cam2.SetActive(false);
            arma.SetActive(false);
            croshair.SetActive(false);
            PlayerFPS.GetComponent<Player_Character>().enabled = true;

        }

        void MovimientoFPS()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            float rotHorizontal = Input.GetAxis("Mouse X");

            Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            transform.Translate(movementDirection * speed * Time.deltaTime);
            transform.Rotate(0, rotHorizontal * speedRot * Time.deltaTime, 0);

        }
    }

}
