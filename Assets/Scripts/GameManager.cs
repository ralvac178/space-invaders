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
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private GameObject player;

    // UI fields
    [SerializeField] private Image lives;
    private RectTransform rectTransformLives;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider shooterBar;

    private float fillValue = 0;

    public TextMeshProUGUI numberBullets;
    public Sprite fillBarBlue, fillBarYellow;
    public Image fillBar;

    private int hopeScore = 2500;

    //Sounds
    public AudioSource audioSource;
    [SerializeField]
    private AudioClip powerUpSound, diePlayerSound, destroyEnemySound, revivalSound, diedSound, newLiveSound;

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

        if (score > hopeScore && score < hopeScore + 150)
        {
            hopeScore += 5000;
            AddLives();
            audioSource.PlayOneShot(newLiveSound);
        }

        shooterBar.value = fillValue;
        audioSource.PlayOneShot(destroyEnemySound);
    }

    public void PlayerDied()
    {
        audioSource.PlayOneShot(diePlayerSound);
        //Restart player
        //Use IEnumerator...
        StartCoroutine(nameof(RestartPlayer));
    }

    public void OnPlayerPickUp(PickupController pickup)
    {
        playerController.OnPlayerPickUp(pickup.pickupConfig.type);
        audioSource.PlayOneShot(powerUpSound);
        score += pickup.pickupConfig.score;
        scoreText.text = score.ToString();
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

    public void AddLives()
    {
        livesPlayer++;
        rectTransformLives.sizeDelta = new Vector2(58 * livesPlayer, 52);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public IEnumerator RestartPlayer()
    {
        audioSource.PlayOneShot(diedSound);
        playerSpriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.7f);
        playerSpriteRenderer.enabled = true;
        playerSpriteRenderer.color = new Color(1, 1, 1, 0.5f);
        player.transform.position = new Vector3(0, -4.1f, 0);
        Collider2D playerCollider = player.GetComponent<Collider2D>();
        playerCollider.enabled = false;
        yield return new WaitForSeconds(4);
        audioSource.PlayOneShot(revivalSound);     
        playerSpriteRenderer.color = new Color(1, 1, 1, 1);
        playerCollider.enabled = true;
        StopCoroutine(RestartPlayer());
    }
}
