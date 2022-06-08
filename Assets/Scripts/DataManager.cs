using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public int highscore;
    public string highscoreName;
    private Dictionary<string, int> playerScores = new Dictionary<string, int>();

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        LoadScore();

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log(playerName);
    }

    [System.Serializable]
    class SaveData
    {
        public string s_playerName;
        public int s_highscore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.s_playerName = highscoreName;
        data.s_highscore = highscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscoreName = data.s_playerName;
            highscore = data.s_highscore;
        }
    }

    public void Exit()
    {
        SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
