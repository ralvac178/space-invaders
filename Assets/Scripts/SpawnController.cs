using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<EnemyWaveConfig> wavesConfigs;
    public float spawnCadence;
    public float initialTime;

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

                SpawnObject(enemy.enemyController.gameObject, enemyPosition);
                yield return new WaitForSeconds(spawnCadence);
            }
            yield return new WaitForSeconds(wave.cadence);
        }
    }

    public void SpawnObject(GameObject prefab, Vector3 position)
    {
        Instantiate(prefab, position, prefab.transform.rotation);
    }
}
