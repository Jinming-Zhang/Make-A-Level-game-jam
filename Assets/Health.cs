using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    [Layer]
    public int instantKillLayer;
    [Scene]
    public int LoadOnDieScene;
    public float maxHealt;
    [ProgressBar("Health", "maxHealt", EColor.Red)]
    public float health = 100;
    [Button("Damage")] // Specify button text
    private void Damage() 
    {
        health -= 10;
    }

    private void Start()
    {
        health = maxHealt;
    }
    private void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(LoadOnDieScene);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.layer + " " + killLayer);
        if (collision.gameObject.layer == instantKillLayer)
        {
            health = 0;
        }
    }
}
