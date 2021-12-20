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
            Debug.Log("--> " + GameManager.Instance.PlayerName);
            GameManager.Instance.QuitGame();
        }

        var playerName = inputField.text;
        startButton.interactable = playerName.Length >= 1;
    }

    public void DisplayOrHideBestScore()
    {
        bestScore.gameObject.SetActive(false);
    }

    public void PrefilPresistentName()
    {
        Debug.Log("--> " + GameManager.Instance.PlayerName);
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
