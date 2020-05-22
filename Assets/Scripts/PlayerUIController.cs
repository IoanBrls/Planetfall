using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
	public Text livesText;
	public Text scoreText;
	public Text wavesText;
	public Text materialsText;

	public GameObject playerObject;
	private Player player;


    // Start is called before the first frame update
    void Start()
    {
		player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + player.lives.ToString();
		scoreText.text = "Score: " + player.score.ToString();
		wavesText.text = "Wave: " + player.waves.ToString();
		materialsText.text = "Materials: " + player.materials.ToString();
	}
}
