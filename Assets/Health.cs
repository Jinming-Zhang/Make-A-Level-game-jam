using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    [ReadOnly]
    public float velocitySum;
    [Layer]
    public int instantKillLayer;
    [Scene]
    public int LoadOnDieScene;
    public float maxHealt;
    [ProgressBar("Health", "maxHealt", EColor.Red)]
    public float health = 100;
    [Button("Damage 10")] // Specify button text
    public void Damage() 
    {
        health -= 10;
    }
    [Button("Heal 10")] // Specify button text
    public void heal()
    {
        health += 10;
    }
    [Button("Kill")] // Specify button text
    public void Kill()
    {
        health = 0;
    }
    [Range(0,10)]
    public float velocityMultiplyer;
    Rigidbody rb;

    private void Start()
    {
        health = maxHealt;
        rb = GetComponent<Rigidbody>();
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
        Vector3 velocity = rb.velocity;
        velocitySum = velocity.x + velocity.y + velocity.z;
        if (collision.gameObject.layer == instantKillLayer)
        {
            health = 0;
            return;
        }
        health -= Mathf.Abs(velocitySum * 2);
    }
}
