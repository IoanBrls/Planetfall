using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The script that manipulates all the sound effects of the game.
//Through this script all the GameObjects of the game can play their respective SFXs.

public class SoundManager : MonoBehaviour
{

	public static SoundManager instance;

	public AudioClip shooting;
	public AudioClip enemyBombs;
	public AudioClip explosion;
	public AudioClip shieldExplosion;
	public AudioClip playerHit;

	private AudioSource SFXsource;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
		{
			instance = this;
		}
		else if (instance == this)
		{
			Destroy(gameObject);
		}

		SFXsource = GetComponent<AudioSource>();
		
    }
	
	public void PlayOneShot(AudioClip clip)
	{
		SFXsource.PlayOneShot(clip);
	}
	
}
