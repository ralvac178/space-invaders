using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public Vector3 spawnPosition;
    public float timeToStart;
    public float cadenceTime;
    public int amount;

    [SerializeField] private List<EnemyConfig> enemyConfigs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(LoopSpawner));
    }
    
    public IEnumerator LoopSpawner()
    {
        yield return new WaitForSeconds(timeToStart);
        for (int i = 0; i < amount; i++)
        {
            float randomXPos = Random.Range(-8.3f, 8.3f);
            spawnPosition = new Vector3(randomXPos, 5.3f, 0);
            SpawnObject(spawnPosition);
            yield return new WaitForSeconds(cadenceTime);
        }
    }

    public void SpawnObject(Vector3 position)
    {
        var enemyInstance = Instantiate(prefab, position, prefab.transform.rotation);
        var enemyControllerComponent = enemyInstance.GetComponent<EnemyController>();
        if (enemyControllerComponent != null)
        {
            int randomEnemyConfig = Random.Range(0, enemyConfigs.Count);
            enemyControllerComponent.enemyConfig = enemyConfigs[randomEnemyConfig];
        }
    }
    
}
