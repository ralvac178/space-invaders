using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score;

    [SerializeField] private PlayerController playerController;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateScoreAndPower(int addScore)
    {
        score += addScore;
        playerController.AddToPower(1);
        Debug.Log(score);
    }

    public void PlayerDied()
    {
        Debug.Log("****** PLAYER DIED ******");
    }
}
