using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Serializable]
    private class GameData
    {
        public string playerName;
        public string bestPlayer;
        public int bestScore;
    }

    public static GameManager Instance;

    public string PlayerName;
    public string BestPlayer;
    public int BestScore;

    private string gameSavePath = "./gamedata.json";
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
        if (File.Exists(gameSavePath))
        {
            var json = File.ReadAllText(gameSavePath);
            var data = JsonUtility.FromJson<GameData>(json);
            PlayerName = data.playerName;
            BestPlayer = data.bestPlayer;
            BestScore = data.bestScore;
        }
    }

    private void SavePersistentData()
    {
        var data = new GameData();
        data.bestPlayer = BestPlayer;
        data.bestScore = BestScore;
        data.playerName = PlayerName;
        
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(gameSavePath, json);
    }
}
