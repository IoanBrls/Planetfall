using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The script that spawns the consecutive waves.

public class Spawner : MonoBehaviour
{
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;

	public GameObject repairMenu;

	private GameObject playerObject;
	private Player player;


	// Start is called before the first frame update
	void Start()
    {
		Spawn();
		playerObject = GameObject.FindWithTag("Player");
		if (playerObject != null)
			player = playerObject.GetComponent<Player>();
	}

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy1").Length +
			GameObject.FindGameObjectsWithTag("Enemy2").Length +
			GameObject.FindGameObjectsWithTag("Enemy3").Length == 0 && player.waves <= 63)
		{
			player.waves++;
			if (player.waves < 64)
			{
				Spawn();

				GameObject.Find("LeftBorder").GetComponent<EnemyShipController>().hasTurned = false;
				GameObject.Find("RightBorder").GetComponent<EnemyShipController>().hasTurned = false;
				repairMenu.GetComponent<RepairMenu>().ActivateMenu();

			}
		}
	}

	void Spawn()
	{
		Vector2 position = transform.position;

		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < 11; j++)
			{
				if (i < 1)
				{
					GameObject enemyShip = Instantiate(enemy3, position, Quaternion.identity);
					enemyShip.transform.parent = gameObject.transform;
					position.x += 0.75f;
				}
				else if (i >= 1 && i < 3)
				{
					GameObject enemyShip = Instantiate(enemy2, position, Quaternion.identity);
					enemyShip.transform.parent = gameObject.transform;
					position.x += 0.75f;
				}
				else
				{
					GameObject enemyShip = Instantiate(enemy1, position, Quaternion.identity);
					enemyShip.transform.parent = gameObject.transform;
					position.x += 0.75f;
				}
			}
			position.x = transform.position.x;
			position.y -= 0.4f;
		}
	}
}
