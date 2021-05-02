using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FpsPlayerInput : MonoBehaviour
{
    public InputAction movement;
    public InputAction turning;

    CharacterController controller;
    public float speed = 5;
    public float mousSensitivity = 1;

    private Camera cam;
    float camRot;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        movement.Enable();
        turning.Enable();
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        movement.Disable();
        turning.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        turn();
    }
    private void Move()
    {
        float x = movement.ReadValue<Vector2>().x;
        float z = movement.ReadValue<Vector2>().y;
        Vector3 direction = transform.right * x + transform.forward * z;

        controller.Move(direction * speed * Time.deltaTime);
    }
    private void turn()
    {
        float mouseX = turning.ReadValue<Vector2>().x * mousSensitivity * Time.deltaTime;
        float mouseY = turning.ReadValue<Vector2>().y * mousSensitivity * Time.deltaTime;

        camRot -= mouseY;
        //camRot = Mathf.Clamp(camRot, -90, 90);
        if(camRot > 90)
        {
            camRot = 90;
        }
        if(camRot < -90)
        {
            camRot = -90;
        }

        cam.transform.localRotation = Quaternion.Euler(camRot, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}
