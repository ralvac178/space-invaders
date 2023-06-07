using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialControllers : MonoBehaviour
{
    //[SerializeField] private GameObject lasser1, lasser2, lasser3, shield, shooter1, shooter2, shooter3;
    [SerializeField] private PlayerController playerController;

    public void OnPlayerPickUp(PickupType pickup)
    {
        StartCoroutine(nameof(GetBackInitShooter));
    }

    public IEnumerator GetBackInitShooter()
    {
        yield return new WaitForSecondsRealtime(15);
        playerController.shooters.Reverse();
    }
}
