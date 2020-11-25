using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
    public Button button;
}
[System.Serializable]
public class PlayerColor
{
    public Color PanelColor;
    public Color TextColor;
}


public class GameController : MonoBehaviour
{

    public Text[] buttonList;
    private string playerSide;

    public GameObject gameOverPanel;
    public Text gameOverText;

    private int countMove;
    public GameObject RestartButton;

    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;

    public GameObject startInfo;

    void Awake()
    {
        gameOverPanel.SetActive(false) ;
        SetGameControllerReferenceOnButton();
        countMove = 0;
        RestartButton.SetActive(false);
    }

    public void SetStartingSide(string startSide)
    {
        playerSide = startSide;
        if (playerSide == "X")
        {
            SetplayerColor(playerX,playerO);
        }
        else
        {
            SetplayerColor(playerO,playerX);
        }
        startGame();
    }

    void startGame()
    {
        SetInteractableButton(true);
        setPlayerButton(false);
        startInfo.SetActive(false);
    }

    void SetGameControllerReferenceOnButton()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        countMove++;

        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if (countMove >= 9)
        {
            GameOver("draw");
        }
        else
        {
            ChangeSide();
        }
       
    }

    void SetplayerColor(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.PanelColor;
        newPlayer.text.color = activePlayerColor.TextColor;
        oldPlayer.panel.color = inactivePlayerColor.PanelColor;
        oldPlayer.text.color = inactivePlayerColor.TextColor;
    }

    void GameOver(string winningPlayer)
    {
        SetInteractableButton(false);
        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a draw!");
            SetplayerColorInactive(); 
        }
        else
        {
            SetGameOverText(winningPlayer + " Wins!");
        }
        
        RestartButton.SetActive(true);
    }

    void ChangeSide()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        if (playerSide == "X")
        {
            SetplayerColor(playerX, playerO);
        }
        else
        {
            SetplayerColor(playerO,playerX);
        }
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    { 
        countMove = 0;
        gameOverPanel.SetActive(false);
        setPlayerButton(true);
        SetplayerColorInactive();
        startInfo.SetActive(true);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }
        RestartButton.SetActive(false);
    }

    void SetInteractableButton(bool change)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = change;
        }
    }

    void setPlayerButton(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    void SetplayerColorInactive()
    {
        playerX.panel.color = inactivePlayerColor.PanelColor;
        playerX.text.color = inactivePlayerColor.TextColor;
        playerO.panel.color = inactivePlayerColor.PanelColor;
        playerO.text.color = inactivePlayerColor.TextColor;
    }
}
