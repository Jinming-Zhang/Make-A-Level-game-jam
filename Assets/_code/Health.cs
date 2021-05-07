using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Health : MonoBehaviour
{
    [Layer]
    public int LaserLayer;
    public float laserDamage;
    [Layer]
    public int MeteoreLayer;
    public float MeteoreDamage;
    [Scene]
    public int LoadOnDieScene;
    public float maxHealt;
    AudioManager audioManager;

    public Slider healthSlider;
    public TMP_Text currHPText;


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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LaserLayer)
        {
            health -= laserDamage;
            healthSlider.value -= laserDamage;
            audioManager.Play("laser");
        }
        if (collision.gameObject.layer == MeteoreLayer)
        {
            health -= MeteoreDamage;
            healthSlider.value -= MeteoreDamage;
            audioManager.Play("meteore");
        }
        currHPText.text = healthSlider.value.ToString();
    }

    private void Start()
    {
        health = maxHealt;
        healthSlider.minValue = 0;
        healthSlider.maxValue = 100;
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(LoadOnDieScene);
        }
    }
}
