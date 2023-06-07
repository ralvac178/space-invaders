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
    }

    public void PlayerDied()
    {
        Debug.Log("****** PLAYER DIED ******");
    }

    public void OnPlayerPickUp(PickupController pickup)
    {
        Debug.Log("Pickup taken");
        playerController.OnPlayerPickUp(pickup.pickupConfig.type);
    }
}
