using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BaricadeSpawner : MonoBehaviour
{
	public GameObject baricadePrefab;

	private Vector2 position1;
	private Vector2 position2;
	private Vector2 position3;
	private Vector2 position4;

	private GameObject baricade1;
	private GameObject baricade2;
	private GameObject baricade3;
	private GameObject baricade4;

	private GameObject playerObject;
	private Player player;

	// Initialize the fixed positions of the baricades/bunkers
	void Start()
    {
		position4 = new Vector2(5, -2);
		position3 = new Vector2(2, -2);
		position2 = new Vector2(-2, -2);
		position1 = new Vector2(-5, -2);

		playerObject = GameObject.FindWithTag("Player");
		if (playerObject != null)
			player = playerObject.GetComponent<Player>();

		SpawnBaricade(0);
    }

	//Spawns the baricade that was selected by the player. The index is given through the buttons of the repair
	//menu and corresponds to the baricade that the player chose to repair.
	//The case of index 0 corresponds to the initiation of the game, where all baricades have to be spawned.
	public void SpawnBaricade(int index)
	{
		if (index == 0)
		{
			baricade1 = Instantiate(baricadePrefab, position1, Quaternion.identity);
			baricade1.transform.parent = gameObject.transform;
			baricade2 = Instantiate(baricadePrefab, position2, Quaternion.identity);
			baricade2.transform.parent = gameObject.transform;
			baricade3 = Instantiate(baricadePrefab, position3, Quaternion.identity);
			baricade3.transform.parent = gameObject.transform;
			baricade4 = Instantiate(baricadePrefab, position4, Quaternion.identity);
			baricade4.transform.parent = gameObject.transform;
		}
		else if (index == 1)
		{
			if (player.materials >= 2000 && baricade1.transform.childCount < 12)
			{
				if (baricade1 != null)
				{
					Destroy(baricade1);
				}

				baricade1 = Instantiate(baricadePrefab, position1, Quaternion.identity);
				baricade1.transform.parent = gameObject.transform;

				var materialsUIComp = GameObject.Find("Materials").GetComponent<Text>();
				player.materials -= 2000;
				materialsUIComp.text = "Materials: " + player.materials.ToString();
			}

		}
		else if (index == 2)
		{
			if (player.materials >= 2000 && baricade2.transform.childCount < 12)
			{
				if (baricade2 != null)
				{
					Destroy(baricade2);
				}

				baricade2 = Instantiate(baricadePrefab, position2, Quaternion.identity);
				baricade2.transform.parent = gameObject.transform;

				var materialsUIComp = GameObject.Find("Materials").GetComponent<Text>();
				player.materials -= 2000;
				materialsUIComp.text = "Materials: " + player.materials.ToString();
			}
		}
		else if (index == 3)
		{
			if (player.materials >= 2000 && baricade3.transform.childCount < 12)
			{
				if (baricade3 != null)
				{
					Destroy(baricade3);
				}

				baricade3 = Instantiate(baricadePrefab, position3, Quaternion.identity);
				baricade3.transform.parent = gameObject.transform;

				var materialsUIComp = GameObject.Find("Materials").GetComponent<Text>();
				player.materials -= 2000;
				materialsUIComp.text = "Materials: " + player.materials.ToString();
			}
		}
		else if (index == 4)
		{
			if (player.materials >= 2000 && baricade4.transform.childCount < 12)
			{
				if (baricade4 != null)
				{
					Destroy(baricade4);
				}

				baricade4 = Instantiate(baricadePrefab, position4, Quaternion.identity);
				baricade4.transform.parent = gameObject.transform;

				var materialsUIComp = GameObject.Find("Materials").GetComponent<Text>();
				player.materials -= 2000;
				materialsUIComp.text = "Materials: " + player.materials.ToString();
			}
		}
	}
}
