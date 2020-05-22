using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is responsible for making the enemy ships move down and turn when they collide with the left or right border.

public class EnemyShipController : MonoBehaviour
{
	public bool hasTurned;
	public GameObject otherWall;

    // Start is called before the first frame update
    void Start()
    {
		hasTurned = false;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 11 && !hasTurned)
		{
			//Debug.Log("TURN");
			
			foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy1"))
			{
				//enemy.GetComponent<Enemy>().MoveDown();
				enemy.GetComponent<Enemy>().Turn();
			}

			foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy2"))
			{
				//enemy.GetComponent<Enemy>().MoveDown();
				enemy.GetComponent<Enemy>().Turn();
			}

			foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy3"))
			{
				//enemy.GetComponent<Enemy>().MoveDown();
				enemy.GetComponent<Enemy>().Turn();
			}

			hasTurned = true;
			otherWall.GetComponent<EnemyShipController>().hasTurned = false;
		}
	}

}
