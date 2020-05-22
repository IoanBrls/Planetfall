using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is the script that keeps track of the player. Basically, it keeps track of the lives,
//the score, the materials and the wave count. It is also the script that is responsible for
//firing projectiles and for restoring the player through the repair menu.

public class Player : MonoBehaviour
{

	private float speed = 5f;

	public GameObject laserBullet;

	public double score;
	public int materials;
	public int lives;
	public float waves;

	private void Start()
	{
		score = 0;
		materials = 0;
		lives = 3;
		waves = 1;
		Time.timeScale = 1f;
	}

	void FixedUpdate()
	{
		float horizontalMovement = Input.GetAxisRaw("Horizontal");

		GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalMovement, 0) * speed;
		
	}

	// Update is called once per frame
	void Update()
    {
        if (Input.GetButtonDown("Jump") && GameObject.FindGameObjectsWithTag("Bullet").Length == 0)
		{
			Instantiate(laserBullet, transform.position, Quaternion.identity);

			SoundManager.instance.PlayOneShot(SoundManager.instance.shooting);
		}
    }

	public void RestoreLives()
	{
		if (materials >= 5000 && lives < 3)
		{
			var materialsUIComp = GameObject.Find("Materials").GetComponent<Text>();
			var livesUIComp = GameObject.Find("Lives").GetComponent<Text>();

			lives = 3;
			materials -= 5000;

			materialsUIComp.text = "Materials: " + materials.ToString();
			livesUIComp.text = "Lives: " + lives.ToString();

		}

	}
}
