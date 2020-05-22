using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//The script that is responsible for creating and keeping track of the current highscores of the game.
//The highscores are being saved using PlayerPrefs.

public class HighScore : MonoBehaviour
{
	private Transform entryContainer;
	private Transform entryTemplate;
	private List<Transform> highScoreEntryTransformList;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			PlayerPrefs.DeleteAll();
		}
	}

	private void Start()
	{
		entryContainer = transform.Find("Container");
		entryTemplate = entryContainer.Find("Entry Template");
		

		entryTemplate.gameObject.SetActive(false);
		
		if (!PlayerPrefs.HasKey("highScoreTable"))
		{
			//Debug.Log("HELLO");
			CreateHighScoreTable();
		}
		//Load High Scores
		string jsonString = PlayerPrefs.GetString("highScoreTable");
		HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

		//Sorting
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

		highScoreEntryTransformList = new List<Transform>();
		for (int i = 0; i < 7; i++)
		{
			if ( i < highscores.highScoreEntryList.Count)
				CreatHighScoreEntryTransform(highscores.highScoreEntryList[i], entryContainer, highScoreEntryTransformList);
		}

		GameObject.FindGameObjectWithTag("HighScore").SetActive(false);
	}

	//Initialization of the highscore table. This is done by adding a defaulted entry to the highscore table.
	//This was done mainly to avoid Null References and game crashes due to an attempt of trying to access the 
	//highscore table at the start of the game.
	private void CreateHighScoreTable()
	{
		List<HighScoreEntry> highScoreEntryList;

		highScoreEntryList = new List<HighScoreEntry>()
		{
			new HighScoreEntry{score = 147500, name = "STAN"}
		};

		HighScores highscores = new HighScores { highScoreEntryList = highScoreEntryList};
		string json = JsonUtility.ToJson(highscores);
		PlayerPrefs.SetString("highScoreTable", json);
		PlayerPrefs.Save();
		//Debug.Log(PlayerPrefs.GetString("highScoreTable"));
	}

	private void CreatHighScoreEntryTransform(HighScoreEntry highscoreEntry, Transform container, List<Transform> transformList)
	{
		float templateHeight = 70f;
		Transform entryTransform = Instantiate(entryTemplate, container);
		RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
		entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
		entryTransform.gameObject.SetActive(true);

		int position = transformList.Count + 1;
		string posString;

		if (position == 1)
			posString = "1ST";
		else if (position == 2)
			posString = "2ND";
		else if (position == 3)
			posString = "3RD";
		else
			posString = position + "TH";

		entryTransform.Find("Position Text").GetComponent<Text>().text = posString;
		entryTransform.Find("Score Text").GetComponent<Text>().text = highscoreEntry.score.ToString();
		entryTransform.Find("Name Text").GetComponent<Text>().text = highscoreEntry.name;
		transformList.Add(entryTransform);
	}

	private void AddHighScoreEntry(int score, string name)
	{
		HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };

		string jsonString = PlayerPrefs.GetString("highScoreTable");
		HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

		highscores.highScoreEntryList.Add(highScoreEntry);

		string json = JsonUtility.ToJson(highscores);
		PlayerPrefs.SetString("highScoreTable", json);
		PlayerPrefs.Save();
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
