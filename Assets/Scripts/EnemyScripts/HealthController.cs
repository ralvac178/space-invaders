using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public int health;
    [SerializeField] private UnityEvent onZeroHealthAction;

    [SerializeField] private AudioClip bossDamageSound;

    public void OnDamage(int damageValue)
    {
        health -= damageValue;
        Debug.Log(health);
        if (health == 0)
        {
            OnZeroHealth();
        }

        GameManager.instance.audioSource.PlayOneShot(bossDamageSound);
        GameManager.instance.UpdateScoreAndPower(100);
    }

    public void OnZeroHealth()
    {
        //onZeroHealthAction?.Invoke();

        if (onZeroHealthAction != null)
        {
            onZeroHealthAction.Invoke();
        }  
    }
}
