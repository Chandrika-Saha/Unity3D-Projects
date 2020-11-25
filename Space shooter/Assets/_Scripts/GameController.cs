using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spwanValues;
    public int spwanCount;
    public float waitTime;
    public float startWait;
    public float waitWait;
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameoverText;

    private int score;
    private bool restart;
    private bool gameover;

    void Start()
    {
        restart = false;
        gameover = false;
        restartText.text = "";
        gameoverText.text = "";
        score = 0;
        updateScore();
        StartCoroutine(spwanWaves());
       
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
     IEnumerator spwanWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < spwanCount; i++)
            {
                Vector3 spwanposition = new Vector3(Random.Range(-spwanValues.x, spwanValues.x), spwanValues.y, spwanValues.z);
                Quaternion spawnrotation = Quaternion.identity;
                Instantiate(hazard, spwanposition, spawnrotation);
                yield return new WaitForSeconds(waitTime);
            }
            yield return new WaitForSeconds(waitWait);
            if (gameover)
            {
                restartText.text = "Press to Restart";
                restart = true;
                break;
            }
        }
    }

     public void addScore(int newScore)
     {
         score += newScore;
         updateScore();
     }

     void updateScore()
     {
         scoreText.text = "Score : " + score;
     }

     public void gameOver()
     {
         gameoverText.text = "Game Over";
         gameover = true;
     }

}
