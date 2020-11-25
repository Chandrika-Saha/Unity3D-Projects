using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreGen : MonoBehaviour {
	private float score = 0.0f;
	private int level = 1;
	private int maxLevel = 10;
	private int scrToMaxLevel = 10;
	public Text scoreVal;
	private bool isdead = false;
	public deathMenu deathmenu;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (isdead)
			return;
		if (score >= scrToMaxLevel)
			levelup ();
		score += Time.deltaTime*level;
		scoreVal.text = ((int)score).ToString();
	}

	void levelup()
	{
		if (level == maxLevel)
			return;
		scrToMaxLevel *= 2;
		level++;
		GetComponent<player>().speedUp (level);
		Debug.Log (level);
	}

	public void onDeath()
	{
		isdead = true;
		if(PlayerPrefs.GetFloat("maxscore") < score)
			PlayerPrefs.SetFloat ("maxscore", score);
		deathmenu.toggleMenu (score);
	}
}
