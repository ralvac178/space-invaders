using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private EnemyConfig enemyConfig;

    private ShooterScript[] shooters;

    //Sounds
    [SerializeField] private AudioClip enemyBulletSound;

    // Start is called before the first frame update
    void Start()
    {
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
                    GameManager.instance.audioSource.PlayOneShot(enemyBulletSound);
                }
            }

            if (enemyConfig.shootCadenceTopLimit != 0)
            {
                float randomCadence = Random.Range(enemyConfig.shootCadence, enemyConfig.shootCadenceTopLimit);
                yield return new WaitForSeconds(randomCadence);
            }
            else
            {
                yield return new WaitForSeconds(enemyConfig.shootCadence);
            }
            
        }
    }
}
