using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<EnemyWaveConfig> wavesConfigs;
    public float spawnCadence;
    public float initialTime;
    [SerializeField] private GameObject enemyBoss;
    [SerializeField] private GameObject[] powerUpPrefabs;

    [SerializeField] private BossBackGroundSong bossBackGroundSongScript;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(SpawnEnemyCorroutine));
        StartCoroutine(nameof(LivesSpawmer));
    }

    public IEnumerator SpawnEnemyCorroutine()
    {
        yield return new WaitForSeconds(initialTime);
        foreach (var wave in wavesConfigs)
        {
            foreach (var enemy in wave.enemies)
            {
                Vector3 enemyPosition = Vector3.zero;
                if (enemy.useEspecifigPosition)
                {
                    enemyPosition = enemy.spawnReferencePosition;
                }
                else
                {
                    enemyPosition = new Vector3(
                        Random.Range(-enemy.spawnReferencePosition.x, enemy.spawnReferencePosition.x),
                        enemy.spawnReferencePosition.y,
                        enemy.spawnReferencePosition.z);
                }

                SpawnObject(enemy.enemyController, enemy.enemyConfig, enemyPosition);
                yield return new WaitForSeconds(spawnCadence);
            }
            yield return new WaitForSeconds(wave.cadence);
        }

        yield return new WaitForSeconds(7);
        Instantiate(enemyBoss);
        bossBackGroundSongScript.ChangeSound();
    }

    public void SpawnObject(EnemyController prefab, EnemyConfig config, Vector3 position)
    {
        var instance = Instantiate(prefab, position, prefab.transform.rotation);
        instance.enemyConfig = config;
    }

    public IEnumerator LivesSpawmer()
    {
        int nItems = 0;
        while (nItems < 24)
        {
            float randomWaitingTime = Random.Range(32,56);
            yield return new WaitForSeconds(randomWaitingTime);
            float xPos = Random.Range(-7.5f, 7.5f);
            float yPos = Random.Range(-4.1f, 4.1f);
            int getPrpowerUp = Random.Range(0, powerUpPrefabs.Length);
            Instantiate(powerUpPrefabs[getPrpowerUp], new Vector3(xPos, yPos, powerUpPrefabs[getPrpowerUp].transform.position.z), powerUpPrefabs[getPrpowerUp].transform.rotation);
        }

        StopCoroutine(LivesSpawmer());
    }
}
