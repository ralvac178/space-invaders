using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerActions : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    private GameObject triggerObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerObject = collision.gameObject;
        action.Invoke();
    }

    public void DestroyObject()
    {
        bool canDestroy = triggerObject != null ? true : false;
        if (canDestroy)
        {
            Destroy(triggerObject);
        }
    }

    public void SetInvisibleObject()
    {
        bool canDestroy = triggerObject != null ? true : false;
        if (canDestroy)
        {
            triggerObject.SetActive(false);
        }
    }
}
