using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class deathMenu : MonoBehaviour {

	public Text deathscr;
	public Image bg;
	private bool isshow = false;
	private float transition = 0.0f;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isshow) {
			return;
		}
		transition += Time.deltaTime;
		bg.color = Color.Lerp (new Color (0, 0, 0, 0), Color.black, transition);
	}

	public void toggleMenu(float score)
	{
		AudioSource audio = GetComponent<AudioSource> ();

		gameObject.SetActive (true);
		audio.Play ();
		deathscr.text = ((int)score).ToString ();
		isshow = true;
	}

	public void resume()
	{
		
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void menu()
	{
		SceneManager.LoadScene ("menu");
	}
}
