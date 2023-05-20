using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerActions : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    protected GameObject triggerObject;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        triggerObject = collision.gameObject;
        action.Invoke();
    }

    public void SetInvisibleObject()
    {
        bool canDestroy = triggerObject != null ? true : false;
        if (canDestroy)
        {
            triggerObject.SetActive(false);
        }
    }

    public void DestroyItself()
    {
        Destroy(this.gameObject);
    }

    public virtual void DestroyCollider()
    {
        if (triggerObject != null)
        {
            Destroy(triggerObject.gameObject);
        }       
    }
}
