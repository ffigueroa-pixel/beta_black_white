using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TPS : MonoBehaviour
{
    public Vector3 desplazamiento;
    public float speedR;
    public float speedW;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speedR = 30;
        speedW = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedR;
        }
        else
        {
            speed = speedW;
        }

        desplazamiento = new Vector3(hor, 0, ver);
        transform.Translate(desplazamiento * speed * Time.deltaTime);
    }
}
