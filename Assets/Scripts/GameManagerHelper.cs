using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerHelper : MonoBehaviour
{
    GameManager gameManager;
    public InputField nameField;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(gameManager != null && gameManager.GetPlayerName() != null)
        {
            nameField.text = gameManager.GetPlayerName();
        }
    }

    public void StartGame()
    {
        if (gameManager != null)
        {
            gameManager.StartGame();
        }
    }

    public void QuitGame()
    {
        if (gameManager != null)
        {
            gameManager.QuitGame();
        }
    }

    public void SetPlayerName(string name)
    {
        if (gameManager != null)
        {
            gameManager.SetPlayerName(name);
        }
    }
}
