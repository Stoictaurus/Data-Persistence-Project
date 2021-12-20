using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button startButton;
    void Start()
    {
        DisplayOrHideBestScore();
        PrefilPresistentName();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.QuitGame();
        }

        var playerName = inputField.text;
        startButton.interactable = playerName.Length >= 1;
    }

    public void DisplayOrHideBestScore()
    {
        if (GameManager.Instance.BestScore > 0)
        {
            bestScore.gameObject.SetActive(true);
            bestScore.text = "Best Score\n" + GameManager.Instance.BestPlayer + ": " + GameManager.Instance.BestScore;
        }
        else
        {
            bestScore.gameObject.SetActive(false);
        }
    }

    public void PrefilPresistentName()
    {
        inputField.text = GameManager.Instance.PlayerName;
    }
    
    public void StartGame()
    {
        GameManager.Instance.PlayerName = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
