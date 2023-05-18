using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Move moveComponent;
    [HideInInspector] public EnemyConfig enemyConfig;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private ShooterScript[] shooters;
    // Start is called before the first frame update
    void Start()
    {
        moveComponent = GetComponent<Move>();
        if (moveComponent != null)
        {
            moveComponent.speed = enemyConfig.speed;
        }

        if (spriteRenderer.sprite != null)
        {
            spriteRenderer.sprite = enemyConfig.sprite;
        }

        if (enemyConfig.isShooter)
        {
            shooters = GetComponentsInChildren<ShooterScript>();
            if (shooters != null && shooters.Length > 0)
            {
                StartCoroutine(nameof(EnemyShooting));
            }
        }
    }

    public void OnDie()
    {
        GameManager.instance.UpdateScoreAndPower(enemyConfig.scoreWhenIsDestroyed);
    }

    public IEnumerator EnemyShooting()
    {
        yield return new WaitForSeconds(enemyConfig.shootInitialWaitTime);
        while (true)
        {
            foreach (var shooter in shooters)
            {
                if (shooter != null)
                {
                    shooter.HasShoot();
                }
            }
            yield return new WaitForSeconds(enemyConfig.shootCadence);
        }
    }
}