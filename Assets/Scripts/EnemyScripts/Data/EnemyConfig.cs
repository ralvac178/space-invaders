using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyConfig", order = 0)]
public class EnemyConfig : ScriptableObject
{
    public float speed;
    public Sprite sprite;
    public bool isShooter;
    public float shootCadence;
    public float shootInitialWaitTime;
}
