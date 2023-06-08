using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Player Config", menuName = "ScriptableObjects/PlayerConfig", order = 0)]
public class PlayerConfig : ScriptableObject
{

    [Serializable]
    public class PowerConfig
    {
        //public int powerValue;
        public int cannonAmount;
    }

    public List<PowerConfig> powerConfigs;

    public PowerConfig GetPowerConfig(int powerValue)
    {
        
        if (powerValue > 14)
        {
            if (powerValue % 15 == 0)
            {
                powerConfigs.Reverse();
            }
        }

        return powerConfigs[0];
    }

    public void SortListCannonAmount()
    {
        if (powerConfigs[0].cannonAmount == 3)
        {
            powerConfigs.Reverse();
        }
    }
}
