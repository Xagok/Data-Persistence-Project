using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private string playerName;
    [SerializeField] private string highestName;
    [SerializeField] private int highScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    [System.Serializable]
    public class SaveData
    {
        public string highestName;
        public int highScore;    
    }
    public string GetHighestName()
    {
        return highestName;
    }
    public void SetHighestName(string name)
    {
        highestName = name;
    }
    public int GetHighScore()
    {
        return highScore;
    }
    public void SetHighScore(int num)
    {
        highScore = num;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.highestName = GetPlayerName();
        data.highScore = GetHighScore();
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/gamesave.json", json);
        Debug.Log(GetPlayerName().ToString());
    }
    private void LoadGame()
    {
        string filePath = Application.persistentDataPath + "/gamesave.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            SetHighestName(data.highestName);
            SetHighScore(data.highScore);
        }else
        {
            Debug.Log("Save file not found!");
            SetHighestName("");
            SetHighScore(0);
        }
    }
}
