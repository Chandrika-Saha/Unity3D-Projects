using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {
    public void ToMain()
    {
        SceneManager.LoadScene("board");
    }
    public void ToMe()
    {
        SceneManager.LoadScene("me");
    }

    public void toMenu()
    {
        SceneManager.LoadScene("UI");
    }

    public void exit()
    {
        Application.Quit();
    }
}
