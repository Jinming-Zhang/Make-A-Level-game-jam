using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NaughtyAttributes;


public class RigidbodyCharacterController : MonoBehaviour
{
    [Foldout("Inputs")]
    public InputAction movement;
    [Foldout("Inputs")]
    public InputAction jump;
    [Foldout("Inputs")]
    public InputAction run;
    [Foldout("Inputs")]
    public InputAction turning;
    [BoxGroup("varibles")]
    public float speed = 5;
    [BoxGroup("varibles")]
    public float runSpeed = 8;
    [BoxGroup("varibles")]
    public float jumpForce;
    public float mousSensitivity = 1;
    [Foldout("Boring")]
    public Transform PlayerCam;
    [Foldout("Boring")]
    public Transform GroundCheck;
    [Foldout("Boring")]
    public float groundDistance = 0.4f;
    [Foldout("Boring")]
    public LayerMask groundMask;
    bool isGrounded;
    float isRuning;
    Rigidbody rb;
    float xRotation;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        movement.Enable();
        turning.Enable();
        jump.Enable();
        run.Enable();
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        movement.Disable();
        turning.Disable();
        jump.Disable();
        run.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
        Jump();
    }
    private void Move()
    {
        float x = movement.ReadValue<Vector2>().x;
        float z = movement.ReadValue<Vector2>().y;
        isRuning = run.ReadValue<float>();
        Vector3 direction = transform.right * x + transform.forward * z;
        if (isRuning == 1)
            rb.AddForce(direction * runSpeed);
        else
            rb.AddForce(direction * speed);

    }
    private void Look()
    {
        float mouseX = turning.ReadValue<Vector2>().x;
        float mouseY = turning.ReadValue<Vector2>().y;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.Rotate(Vector3.up * mouseX);
        PlayerCam.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
    private void Jump()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        if(jump.ReadValue<float>() == 1 && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
