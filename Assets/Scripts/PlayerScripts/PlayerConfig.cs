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
    private List<string> numberBullets = new List<string>(){ "1", "3" };

    public PowerConfig GetPowerConfig(int powerValue)
    {
        
        if (powerValue > 14)
        {
            if (powerValue % 15 == 0)
            {
                powerConfigs.Reverse();
                numberBullets.Reverse();
            }
        }

        GameManager.instance.numberBullets.text = numberBullets[0];
        return powerConfigs[0];
    }

    public void SortListCannonAmount()
    {
        if (powerConfigs[0].cannonAmount == 3)
        {
            powerConfigs.Reverse();
            numberBullets.Reverse();
        }
    }
}
