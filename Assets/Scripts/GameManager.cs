using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string PlayerName;
    public string BestPlayer;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
        RestorePersistentData();
    }

    public void QuitGame()
    {
        SavePersistentData();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ReportScore(int score)
    {
        if (score > BestScore)
        {
            BestScore = score;
            BestPlayer = PlayerName;
        }
    }
    
    private void RestorePersistentData()
    {
        
    }

    private void SavePersistentData()
    {
        
    }
}
