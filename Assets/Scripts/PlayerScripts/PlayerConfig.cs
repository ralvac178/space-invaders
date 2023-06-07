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
        //foreach (var config in powerConfigs)
        //{
        //    if (config.powerValue >= powerValue)
        //    {
        //        return config;
        //    }
        //}

        if (powerValue % 15 == 0)
        {
            powerConfigs.Reverse();
        }

        return powerConfigs[0];
    }
}
