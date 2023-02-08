using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
  
    private float yaw = 0f;
    private float pitch = 0f;
    Transform playerBody;
    public float mouseSensitivity = 100;

    GameObject player;
    Vector3 offset;

    void Start()
    {
        playerBody = transform.parent.transform;
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        float moveX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float moveY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
     

        playerBody.Rotate(Vector3.up * moveX);

        pitch -= moveY;

        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
