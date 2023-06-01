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
    public float shootCadenceTopLimit;
    public float shootInitialWaitTime;
    public int scoreWhenIsDestroyed;
    [Range(0, 1f)] public float pickUpChance;

    public bool ShouldTroughPickUp()
    {
        return Dice.IsChanceSucces(pickUpChance);
    }
}
