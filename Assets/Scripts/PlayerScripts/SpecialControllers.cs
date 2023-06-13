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
            GameManager.instance.fillBar.sprite = GameManager.instance.fillBarYellow;
            GameManager.instance.numberBullets.color = Color.green;
            StartCoroutine(nameof(GetBackInitShooter));
        }
        else if (pickup == PickupType.Shield)
        {
            shield.SetActive(true);
            shielded = true;
        }
        else
        {
            GameManager.instance.AddLives();
        }
    }

    public IEnumerator GetBackInitShooter()
    {
        yield return new WaitForSecondsRealtime(15);
        GameManager.instance.fillBar.sprite = GameManager.instance.fillBarBlue;
        GameManager.instance.numberBullets.color = Color.white;
        playerController.shooters.Reverse();
    }

    public void OnShieldDestroyed()
    {
        shield.SetActive(false);
    }
}
