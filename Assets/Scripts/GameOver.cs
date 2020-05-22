﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//A script that implements the Game Over Screen and saves the highscore once the player loses.

public class GameOver : MonoBehaviour
{
	public GameObject playerObject;
	private Player player;
	private bool highScoreFlag = false;

	public GameObject gameOverUI;
	public GameObject gameOverText;
	public GameObject gameOverUI2;
	public GameObject gameOverText2;
	public GameObject inputField;

    // Start is called before the first frame update
    void Start()
    {
		player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.lives <= 0)
		{
			string jsonString = PlayerPrefs.GetString("highScoreTable");
			HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

			for (int i = 0; i < highscores.highScoreEntryList.Count; i++)
			{
				for (int j = i + 1; j < highscores.highScoreEntryList.Count; j++)
				{
					if (highscores.highScoreEntryList[j].score > highscores.highScoreEntryList[i].score)
					{
						HighScoreEntry tmp = highscores.highScoreEntryList[i];
						highscores.highScoreEntryList[i] = highscores.highScoreEntryList[j];
						highscores.highScoreEntryList[j] = tmp;
					}
				}
			}

			if (highscores.highScoreEntryList.Count >= 7)
			{
				for (int i = 0; i < 7; i++)
				{
					if (player.score > highscores.highScoreEntryList[i].score)
					{
						highScoreFlag = true;
						break;
					}
				}
			}
			
			if (highScoreFlag || highscores.highScoreEntryList.Count < 7)
			{
				gameOverUI.SetActive(true);
				gameOverText.SetActive(true);
			}
			else
			{
				gameOverUI2.SetActive(true);
				gameOverText2.SetActive(true);
			}
		}
    } 

	public void SubmitHighScore()
	{
		if(inputField.GetComponent<Text>().text.Length >= 2)
		{
			string theName = inputField.GetComponent<Text>().text;
			HighScoreEntry highScoreEntry = new HighScoreEntry { score = player.score, name = theName };

			string jsonString = PlayerPrefs.GetString("highScoreTable");
			HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

			highscores.highScoreEntryList.Add(highScoreEntry);

			string json = JsonUtility.ToJson(highscores);
			PlayerPrefs.SetString("highScoreTable", json);
			PlayerPrefs.Save();

			SceneManager.LoadScene(0);
		}

	}

	public void Quit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}

	[System.Serializable]
	private class HighScoreEntry
	{
		public double score;
		public string name;
	}

	[System.Serializable]
	private class HighScores
	{
		public List<HighScoreEntry> highScoreEntryList;
	}
}
