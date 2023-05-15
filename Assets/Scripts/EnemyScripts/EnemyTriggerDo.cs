using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTriggerDo : MonoBehaviour
{
    [SerializeField] private UnityEvent alwaysActions;
    [SerializeField] private UnityEvent unIgnoreActions;

    [SerializeField] private List<string> tagsToIgnore;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
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
}
