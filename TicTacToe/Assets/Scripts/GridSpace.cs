using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GridSpace : MonoBehaviour
{

    public Button button;
    public Text buttonText;
    
    private GameController gameController;

    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }
    public void setSpace()
    {
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
       // EventSystem.current.SetSelectedGameObject(null);
        gameController.EndTurn();
    }

}
