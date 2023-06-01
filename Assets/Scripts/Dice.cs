using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Dice
{
    public static bool IsChanceSucces(float chance)
    {
        var randomValue = Random.Range(0, 1f);
        return chance > randomValue;
    }
}
