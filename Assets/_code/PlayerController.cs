using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [ReadOnly]
    public Vector3 rawInputMovement;
    public float speed;
    private Rigidbody rb;
    [Foldout("particles")]
    public GameObject left;
    [Foldout("particles")]
    public GameObject right;
    [Foldout("particles")]
    public GameObject up;
    [Foldout("particles")]
    public GameObject down;
    public bool IsInverted;
    AudioManager audioManager;
    bool playing;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rawInputMovement != Vector3.zero && !playing)
        {
            audioManager.Play("air");
            Debug.Log("play");
            playing = true;
        }
        if(rawInputMovement == Vector3.zero)
        {
            audioManager.Stop("air");
            Debug.Log("stop");
            playing = false;
        }
        if (!IsInverted)
        {
            rb.AddForce(rawInputMovement * speed * Time.deltaTime);
            if (rawInputMovement.x > 0)
            {
                left.SetActive(true);
                right.SetActive(false);
            }
            else if (rawInputMovement.x != 0)
            {
                left.SetActive(false);
                right.SetActive(true);
            }
            else
            {
                left.SetActive(false);
                right.SetActive(false);
            }

            if (rawInputMovement.y > 0)
            {
                down.SetActive(true);
                up.SetActive(false);
            }
            else if (rawInputMovement.y != 0)
            {
                down.SetActive(false);
                up.SetActive(true);
            }
            else
            {
                down.SetActive(false);
                up.SetActive(false);
            }
        }
        else
        {
            rb.AddForce(-rawInputMovement * speed * Time.deltaTime);
            if (rawInputMovement.x > 0)
            {
                right.SetActive(true);
                left.SetActive(false);
            }
            else if (rawInputMovement.x != 0)
            {
                right.SetActive(false);
                left.SetActive(true);
            }
            else
            {
                right.SetActive(false);
                left.SetActive(false);
            }


            if (rawInputMovement.y > 0)
            {
                up.SetActive(true);
                down.SetActive(false);
            }
            else if (rawInputMovement.y != 0)
            {
                up.SetActive(false);
                down.SetActive(true);
            }
            else
            {
                up.SetActive(false);
                down.SetActive(false);
            }
        }
    }
    public void onMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, inputMovement.y, 0);
    }
    public void onReset(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void onPlayerStop(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            rb.AddForce(rb.velocity * -1 * 30);
        }
    }
}
