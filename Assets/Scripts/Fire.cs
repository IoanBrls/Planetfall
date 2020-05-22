using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//The script that implements how the friendly projectiles interact with the environment.

public class Fire : MonoBehaviour
{
	public float speed = 7;
	private GameObject playerObject;
	private Player player;

	private Rigidbody2D rigidBody;

	public Sprite explodedEnemySprite;

    // Start is called before the first frame update
    void Start()
    {
		rigidBody = GetComponent<Rigidbody2D>();

		rigidBody.velocity = Vector2.up * speed;

		playerObject = GameObject.FindWithTag("Player");
		if (playerObject != null)
			player = playerObject.GetComponent<Player>();
    }

	//If the friendly laser beam collides with an enemy, then destroy that enemy and increase the score and materials.
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Border")
		{
			Destroy(gameObject);
		}

		if (collision.tag == "Enemy1")
		{
			SoundManager.instance.PlayOneShot(SoundManager.instance.explosion);
			IncreaseScore(1);

			collision.GetComponent<SpriteRenderer>().sprite = explodedEnemySprite;

			Destroy(gameObject);
			Destroy(collision.gameObject, 0.25f);
		}

		if (collision.tag == "Enemy2")
		{
			SoundManager.instance.PlayOneShot(SoundManager.instance.explosion);
			IncreaseScore(2);

			collision.GetComponent<SpriteRenderer>().sprite = explodedEnemySprite;

			Destroy(gameObject);
			Destroy(collision.gameObject, 0.25f);
		}

		if (collision.tag == "Enemy3")
		{
			SoundManager.instance.PlayOneShot(SoundManager.instance.explosion);
			IncreaseScore(3);

			collision.GetComponent<SpriteRenderer>().sprite = explodedEnemySprite;

			Destroy(gameObject);
			Destroy(collision.gameObject, 0.25f);
		}

		if (collision.tag == "Shield")
		{
			SoundManager.instance.PlayOneShot(SoundManager.instance.shieldExplosion);
			Destroy(gameObject);
			Destroy(collision.gameObject);
		}
	}

	void IncreaseScore(int enemyFlag)
	{

		if (enemyFlag == 1)
		{
			player.score += 10;
			player.materials += 100;
		}
		else if (enemyFlag == 2)
		{
			player.score += 50;
			player.materials += 150;
		}
		else if (enemyFlag == 3)
		{
			player.score += 200;
			player.materials += 250;
		}
		

	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
