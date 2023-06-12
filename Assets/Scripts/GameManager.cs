using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score;
    public int livesPlayer = 3;

    [SerializeField] private PlayerController playerController;

    // UI fields
    [SerializeField] private Image lives;
    private RectTransform rectTransformLives;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider shooterBar;

    private float fillValue = 0;

    public TextMeshProUGUI numberBullets;
    public Sprite fillBarBlue, fillBarYellow;
    public Image fillBar;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rectTransformLives = lives.GetComponent<RectTransform>();
        rectTransformLives.sizeDelta = new Vector2(58 * livesPlayer, 52);
        scoreText.text = score.ToString();

        shooterBar.value = playerController.powerLevel;
    }

    public void UpdateScoreAndPower(int addScore)
    {
        score += addScore;
        playerController.AddToPower(1);
        scoreText.text = score.ToString();

        if (playerController.powerLevel < 15)
        {
            fillValue = playerController.powerLevel;
        }
        else
        {
            fillValue = playerController.powerLevel % 15;
        }

        shooterBar.value = fillValue;
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

        rectTransformLives.sizeDelta = new Vector2(58 * livesPlayer ,52);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
