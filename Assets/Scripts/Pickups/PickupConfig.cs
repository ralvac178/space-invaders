using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Name,
    Lasser,
    Shield,
    Lives
}

[CreateAssetMenu(fileName = "Pickup", menuName = "Pickup/Player", order = 1)]

public class PickupConfig : ScriptableObject
{
    public PickupType type;
    public int score;
}
