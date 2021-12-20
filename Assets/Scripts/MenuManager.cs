using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private TMP_InputField inputField;
    
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
            QuitGame();
        }
    }

    public void DisplayOrHideBestScore()
    {
        bestScore.gameObject.SetActive(false);
    }

    public void PrefilPresistentName()
    {
        inputField.text = "";
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
