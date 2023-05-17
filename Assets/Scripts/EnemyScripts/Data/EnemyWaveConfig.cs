using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Enemy Wave", menuName = "ScriptableObjects/EnemyWaveConfig", order = 0)]
public class EnemyWaveConfig : ScriptableObject
{
    [Serializable]
    public class EachEnemyConfig
    {
        public EnemyController enemyController;
        public Vector3 spawnReferencePosition;
        public bool useEspecifigPosition;
        public EnemyConfig enemyConfig;
    }

    public List<EachEnemyConfig> enemies;
    public float cadence;
}
