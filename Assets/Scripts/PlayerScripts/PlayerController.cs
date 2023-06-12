using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] public List<ShooterScript> shooters;
    [SerializeField] private SpecialControllers specialControllers;

    public int powerLevel;
    private int cannonUnlocked = 1;
    
    private void Start()
    {
        if (gameObject.tag.Equals("Player"))
        {
            InputProvider.OnHasShoot += OnHasShoot;
        }
    }

    public void AddToPower(int powerToAdd)
    {
        powerLevel += powerToAdd;

        //Check how many cannons player has
        var powerConfig = playerConfig.GetPowerConfig(powerLevel);
        cannonUnlocked = powerConfig.cannonAmount;
    }

    public void OnHasShoot()
    {
        for (int i = 0; i < cannonUnlocked; i++)
        {
            var shooter = shooters[i];
            shooter.HasShoot();
        }
    }

    private void OnDestroy()
    {
        if (gameObject.tag.Equals("Player"))
        {
            InputProvider.OnHasShoot -= OnHasShoot;
        }

        playerConfig.SortListCannonAmount();
    }

    public void OnSubLives()
    {
        if (!specialControllers.shielded)
        {
            GameManager.instance.SubLives();
        }
        else
        {
            specialControllers.shielded = false;
            specialControllers.OnShieldDestroyed();
        }
        
    }

    public void OnPlayerPickUp(PickupType pickupType)
    {
        bool enReverse = shooters[0].name.Contains("Lasser");
        if (!enReverse)
        {
            shooters.Reverse();   
        }
        
        specialControllers.OnPlayerPickUp(pickupType);
    }
}
