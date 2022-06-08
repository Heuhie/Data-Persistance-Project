using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public TMP_Text highScore;

    private void Start()
    {
        highScore.text = DataManager.Instance.highscoreName + "    SCORE: " + DataManager.Instance.highscore;
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
