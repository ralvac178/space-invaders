using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialControllers : MonoBehaviour
{
    public GameObject shield;
    public bool shielded = false;
    [SerializeField] private PlayerController playerController;

    public void OnPlayerPickUp(PickupType pickup)
    {
        if (pickup == PickupType.Lasser)
        {
            StopAllCoroutines();
            StartCoroutine(nameof(GetBackInitShooter));
        }
        else
        {
            shield.SetActive(true);
            shielded = true;
        }
    }

    public IEnumerator GetBackInitShooter()
    {
        yield return new WaitForSecondsRealtime(15);
        playerController.shooters.Reverse();
    }

    public void OnShieldDestroyed()
    {
        shield.SetActive(false);
    }
}
