using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int Score = 0;
    public static int Highscore = 0;

    public static ScoreScript Instance;
    
    private void Awake()
    {
        Instance = this;
    }
    
}
