using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Move moveComponent;
    [HideInInspector] public EnemyConfig enemyConfig;
    // Start is called before the first frame update
    void Start()
    {
        moveComponent = GetComponent<Move>();
        if (moveComponent != null)
        {
            moveComponent.speed = enemyConfig.speed;
        }
    }
}
