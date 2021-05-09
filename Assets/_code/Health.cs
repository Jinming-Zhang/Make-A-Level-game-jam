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
	public float kickback;
	AudioManager audioManager;

	public Slider healthSlider;
	public TMP_Text currHPText;
	Rigidbody rb;


	[ProgressBar("Health", "maxHealt", EColor.Red)]
	public float health = 100;
	public float HealthSync { get { return health; } set { health = value; UpdateHealthbarUI(); } }
	[Button("Damage 10")] // Specify button text
	public void Damage()
	{
		HealthSync -= 10;
	}
	[Button("Heal 10")] // Specify button text
	public void heal()
	{
		HealthSync += 10;
	}
	[Button("Kill")] // Specify button text
	public void Kill()
	{
		HealthSync = 0;
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == LaserLayer)
		{
			health -= laserDamage;
			UpdateHealthbarUI();
			if (audioManager != null)
			{
				audioManager.Play("laser");
			}
			ApplyForce(collision.transform);
		}
		if (collision.gameObject.layer == MeteoreLayer)
		{
			health -= MeteoreDamage;
			UpdateHealthbarUI();
			if (audioManager != null)
			{
				audioManager.Play("meteore");
			}
		}
	}

	private void UpdateHealthbarUI()
	{
		healthSlider.value = health;
		currHPText.text = healthSlider.value.ToString();
	}

	private void Start()
	{
		health = maxHealt;
		healthSlider.minValue = 0;
		healthSlider.maxValue = 100;
		audioManager = FindObjectOfType<AudioManager>();
		rb = GetComponent<Rigidbody>();
	}
	private void Update()
	{
		health = Mathf.Clamp(health, 0, maxHealt);
		if (health <= 0)
		{
			if (audioManager != null)
			{
				audioManager.Play("over");
				audioManager.Stop("air");
				audioManager.Stop("mayday");
				audioManager.Stop("correct");
				audioManager.Stop("wrong");
				audioManager.Stop("laser");
				audioManager.Stop("meteore");
			}
			SceneManager.LoadScene(LoadOnDieScene);
		}
	}
	void ApplyForce(Transform laser)
	{
		rb.AddExplosionForce(kickback, laser.position, 1000);
	}
}
