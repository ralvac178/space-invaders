using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score;
    public int livesPlayer = 3;

    [SerializeField] private PlayerController playerController;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateScoreAndPower(int addScore)
    {
        score += addScore;
        playerController.AddToPower(1);
    }

    public void PlayerDied()
    {
        Debug.Log("****** PLAYER DIED ******");
    }

    public void OnPlayerPickUp(PickupController pickup)
    {
        playerController.OnPlayerPickUp(pickup.pickupConfig.type);
    }

    public void SubLives()
    {
        
        if (livesPlayer > 1)
        {
            Debug.Log(livesPlayer);
            livesPlayer--;
            PlayerDied();
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
