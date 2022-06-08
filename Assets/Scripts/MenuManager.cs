using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public TMP_Text inputPlayerName;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(inputPlayerName);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        DataManager.Instance.playerName = inputPlayerName.text;
        Debug.Log(inputPlayerName);
    }

    public void GoToHighScore()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        DataManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
