using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairMenu : MonoBehaviour
{
	public GameObject repairMenuUI;
	public GameObject repairMenuText;
	// Update is called once per frame


	public void Resume()
	{
		repairMenuText.SetActive(false);
		repairMenuUI.SetActive(false);
		Time.timeScale = 1f;
	}

	public void ActivateMenu()
	{
		repairMenuText.SetActive(true);
		repairMenuUI.SetActive(true);
		Time.timeScale = 0f;
	}
}
