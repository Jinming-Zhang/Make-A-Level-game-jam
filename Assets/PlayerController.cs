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
    public GameObject left;
    public GameObject rigt;
    public GameObject up;
    public GameObject down;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(rawInputMovement * speed * Time.deltaTime);
        if(rawInputMovement.x > 0)
        {
            left.SetActive(true);
            rigt.SetActive(false);
        }
        else if (rawInputMovement.x != 0)
        {
            left.SetActive(false);
            rigt.SetActive(true);
        }
        else
        {
            left.SetActive(false);
            rigt.SetActive(false);
        }


        if (rawInputMovement.y > 0)
        {
            down.SetActive(true);
            up.SetActive(false);
        }
        else if(rawInputMovement.y != 0)
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
    public void onMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, inputMovement.y, 0);
    }
    public void onReset(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
