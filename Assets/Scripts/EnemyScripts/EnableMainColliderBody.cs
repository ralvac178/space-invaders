using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnableMainColliderBody : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyParts;
    private bool enableBodyCollider = false;
    private bool enableInvoke = true;
    [SerializeField] private UnityEvent unityEvent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyParts.Length; i++)
        {
            if (enemyParts[i].gameObject != null)
            {
                enableBodyCollider = true;
                break;
            }
            else
            {
                enableBodyCollider = false;
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enableBodyCollider)
        {
            unityEvent?.Invoke();
        }
    }
}
