using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM_FPS : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject arma;
    public GameObject croshair;
    public float xspeed;
    public GameObject PlayerFPS;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivarCamaras();
    }

    void ActivarCamaras()
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
    }

    void MovimientoFPS()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movementDirection*xspeed*Time.deltaTime);
    }
}
