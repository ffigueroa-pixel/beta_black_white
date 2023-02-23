using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS : MonoBehaviour
{
    public Vector3 desplazamiento;
    public float speed;
    public float speedW;
    public float speedR;

    public GameObject camUno;
    public GameObject camDos;
    // Start is called before the first frame update
    void Start()
    {
        speedW = 10;
        speedR = 30;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        float hor = (Input.GetAxis("Horizontal"));
        float ver = (Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedR;
        }
        else
        {
            speed = speedW;
        }

        desplazamiento = new Vector3(hor, ver, 0);
        transform.Translate(desplazamiento * speed * Time.deltaTime);
    }
}
