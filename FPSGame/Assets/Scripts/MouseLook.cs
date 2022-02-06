using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;

    public float mouseSensitivity = 50f;
    public float speed = 5f;
    public float maxDistance;

    float xRotation = 0f;
    //float waitTime = 0.5f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        RotatceCamera();

        
       

    }
    void RotatceCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

   
}
