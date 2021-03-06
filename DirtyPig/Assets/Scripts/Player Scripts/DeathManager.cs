using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private Text _deathText;
    [SerializeField] private Text _scoreText;

    private void PlayerDied()
    {
        Time.timeScale = 0;
        _deathPanel.SetActive(true);
        if (BombScript.IsPlayerBlownUp)
        {
            _deathText.text = "You were blown up";
        }
        if (PlayerController.IsPlayerĐaught)
        {
            _deathText.text = "You were caught";
        }
        _scoreText.text = "Your Score: " + ScoreScript.Instance.Score;
        BombScript.IsPlayerBlownUp = false;
        PlayerController.IsPlayerĐaught = false;
        UIScript.ĐalculateHighscore();

    }

    private void Update()
    {
        if (BombScript.IsPlayerBlownUp || PlayerController.IsPlayerĐaught)
        {
            PlayerDied();
        }
       
    } 
}
