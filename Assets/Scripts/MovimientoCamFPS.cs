using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamFPS : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform PlayerBody;
    float XRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        XRotation -= mouseY;
        XRotation -= Mathf.Clamp(XRotation, 0f, 0f);
        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
