using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The purpose of this script is to provide a further notification that the player got hit,
//by "flashing" a red panel on the screen.

public class DamageEffect : MonoBehaviour
{

	public GameObject redPanel;

    
    void Start()
    {
		redPanel.SetActive(false);
    }

    public IEnumerator DamageIndicator()
	{
		redPanel.SetActive(true);
		yield return StartCoroutine(DisableDamageIndicator());
	}

	public IEnumerator DisableDamageIndicator()
	{
		yield return new WaitForSeconds(0.1f);
		redPanel.SetActive(false);
	}
}
