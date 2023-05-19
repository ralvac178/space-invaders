using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public int health;
    [SerializeField] private UnityEvent onZeroHealthAction;

    public void OnDamage(int damageValue)
    {
        health -= damageValue;
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
