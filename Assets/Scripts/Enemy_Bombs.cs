using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The script that controls the enemy projectiles.
//Basically the projectile is initialized to move downwards on the y axis and have different
//interactions when it collides with a bunker or with a player.

public class Enemy_Bombs : MonoBehaviour
{

	private Rigidbody2D rigidBody;

	private float speed = 3;
	public Sprite explodedShipSprite;

	private GameObject playerObject;
	private Player player;
	private DamageEffect redPanel;

	// Start is called before the first frame update
	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.velocity = Vector2.down * speed;
		

		playerObject = GameObject.FindWithTag("Player");
		redPanel = playerObject.GetComponent<DamageEffect>();
		if (playerObject != null)
			player = playerObject.GetComponent<Player>();
	}
	 
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Border")
		{
			Destroy(gameObject);
		}

		if (collision.tag == "Player")
		{

			SoundManager.instance.PlayOneShot(SoundManager.instance.playerHit);
			StartCoroutine(redPanel.DamageIndicator());
			player.lives -= 1;

			if (player.lives <= 0)
			{
				collision.GetComponent<SpriteRenderer>().sprite = explodedShipSprite;
				SoundManager.instance.PlayOneShot(SoundManager.instance.explosion);

				Destroy(collision.gameObject, 0.5f);
				Time.timeScale = 0f;

			}

			Destroy(gameObject);
		}

		if (collision.tag == "Shield")
		{
			SoundManager.instance.PlayOneShot(SoundManager.instance.shieldExplosion);
			Destroy(gameObject);
			Destroy(collision.gameObject);
		}
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
