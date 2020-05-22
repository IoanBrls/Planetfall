using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//The script that controls the enemy units.
//The main variables of the enemy are its position, its fireDelay which determines how often the enemy ship 
//will fire lasers and the speed which determines how fast the ships will go left and right.

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private float speed;
	private Rigidbody2D rigidBody;


	private SpriteRenderer spriteRenderer;
	public Sprite explodedShipSprite;
	public float changeSeconds = 0.5f;

	public GameObject enemyLaser;
	private float minFireRate = 0.0f;
	private float maxFireRate;
	[SerializeField]
	private float fireDelay = 3.0f;

	private GameObject playerObject;
	private Player player;

	private int direction;
	
	
	void Start()
    {
		rigidBody = GetComponent<Rigidbody2D>();
		

		spriteRenderer = GetComponent<SpriteRenderer>();
		
		direction = 1;

		playerObject = GameObject.FindWithTag("Player");
		if (playerObject != null)
			player = playerObject.GetComponent<Player>();

		maxFireRate = 70f - Mathf.Lerp(0f, 50f, player.waves / 64);
		fireDelay = fireDelay + Time.time + Random.Range(minFireRate, maxFireRate);
		speed = Mathf.Lerp(0.5f, 4f, player.waves / 64);
		//speed = 0.5f * (1 - (player.waves / 64)) + 4f * (player.waves / 64);
		rigidBody.velocity = new Vector2(1, 0) * speed;
	}

	//Makes the ship go to a different direction.
	public void Turn ()
	{
		direction = -direction;
		MoveDown();
		//Vector2 newVelocity = new Vector2(1,0) * direction * speed;
		//newVelocity.x = speed * direction;
		rigidBody.velocity = new Vector2(1, 0) * direction * speed;

	}

	//Moves the ship down on the y axis.
	public void MoveDown()
	{
		Vector2 position = transform.position;
		speed += 0.1f;
		position.y -= 0.1f;
		transform.position = position;

	}

	// Update is called once per frame
	void FixedUpdate()
    {
        if (Time.time > fireDelay)
		{
			fireDelay = fireDelay + Random.Range(minFireRate, maxFireRate);

			Instantiate(enemyLaser, transform.position, Quaternion.identity);
		}

		if (transform.position.y < -3.4f)
		{
			player.lives = 0;
			Time.timeScale = 0f;
		}
	}

	//if an enemy ship collides with the player then the player loses one life.
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{

			SoundManager.instance.PlayOneShot(SoundManager.instance.playerHit);

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
	}
}
