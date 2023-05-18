using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTriggerDo : TriggerActions
{
    [SerializeField] private UnityEvent alwaysActions;
    [SerializeField] private UnityEvent unIgnoreActions;

    [SerializeField] private List<string> tagsToIgnore;
    // Start is called before the first frame update
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        alwaysActions.Invoke();
        foreach (var tagToIgnore in tagsToIgnore)
        {
            if (tagToIgnore.Equals(collision.tag))
            {
                return;
            }
        }
        unIgnoreActions.Invoke();
    }

    public override void DestroyCollider()
    {
        if (triggerObject != null)
        {
            Destroy(triggerObject.gameObject);
        }
    }
}
