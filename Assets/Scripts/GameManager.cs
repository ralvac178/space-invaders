using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        Debug.Log(score);
    }
}
