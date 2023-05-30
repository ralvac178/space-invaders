using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BigExplotionEnemyBoss : MonoBehaviour
{
    [SerializeField] private List<GameObject> explotionsParticles;
    private GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunExplotions());
    }

    private void Update()
    {
              
    }

    public IEnumerator RunExplotions()
    {
        foreach (var explotion in explotionsParticles)
        {
            explotion.SetActive(true);
            yield return new WaitForSeconds(0.05f);
        }

        StopCoroutine(RunExplotions());
    }

    public void GetBossPos()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            transform.position = new Vector3(boss.transform.position.x, boss.transform.position.y + 5f,
                boss.transform.position.z);
        }
    }
}
