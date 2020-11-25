using UnityEngine;
using System.Collections;

public class destroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerEx;
    public int scoreValue;
    private GameController gameContoller;

    void Start()
    {
        GameObject gameControllerSearch = GameObject.FindWithTag("GameController");
        if (gameControllerSearch != null)
        {
            gameContoller = gameControllerSearch.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("cannot find 'gamecontroller'");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerEx, other.transform.position, other.transform.rotation);
            gameContoller.gameOver();
        }
        gameContoller.addScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
