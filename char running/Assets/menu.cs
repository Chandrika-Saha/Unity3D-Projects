using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {
	public Text maxscr;
	// Use this for initialization
	void Start () {
		maxscr.text = "High Score : " + ((int)PlayerPrefs.GetFloat ("maxscore")).ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play()
	{
		SceneManager.LoadScene ("runn");
	}
}
