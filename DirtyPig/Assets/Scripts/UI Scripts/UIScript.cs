using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highscoreText;

    private static string _highscoreKey = "HighscoreKey";

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public static void ÑalculateHighscore()
    {
        if (ScoreScript.Highscore <= ScoreScript.Instance.Score)
        {
            ScoreScript.Highscore = ScoreScript.Instance.Score;
        }
        PlayerPrefs.SetInt(_highscoreKey, ScoreScript.Highscore);
    }

    private void Awake()
    {
        ScoreScript.Highscore = PlayerPrefs.GetInt(_highscoreKey);
        _highscoreText.text = "Highscore: " + ScoreScript.Highscore;
    }

    private void Update()
    {
        _scoreText.text = "Score: " + ScoreScript.Instance.Score;
    }

}
