using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<EnemyWaveConfig> wavesConfigs;
    public float spawnCadence;
    public float initialTime;
    [SerializeField] private GameObject enemyBoss;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(SpawnEnemyCorroutine));
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
    }

    public void SpawnObject(EnemyController prefab, EnemyConfig config, Vector3 position)
    {
        var instance = Instantiate(prefab, position, prefab.transform.rotation);
        instance.enemyConfig = config;
    }
}
