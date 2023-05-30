using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] Move move;
    private bool dir = true;
    private bool beginHorMovement = false;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private HealthController healthController;

    // Update is called once per frame
    void Update()
    {
        if (beginHorMovement)
        {
            beginHorMovement = false;
            StartCoroutine(Translation());
        }
    }

    public IEnumerator Translation()
    {
        while(healthController.health > 0)
        {
            if (dir)
            {
                move.direction = Vector3.right;
            }
            else
            {
                move.direction = Vector3.left;
            }
            
            if (transform.position.x >= 5)
            {
                
                transform.position = new Vector3(5, transform.localPosition.y, transform.localPosition.z);
                move.direction = Vector3.zero;
                yield return new WaitForSeconds(4);
                dir = false;
                move.direction = Vector3.left;
            }
            else if (transform.position.x <= -5)
            {
                
                transform.position = new Vector3(-5, transform.localPosition.y, transform.localPosition.z);
                move.direction = Vector3.zero;
                yield return new WaitForSeconds(4);
                dir = true;
                move.direction = Vector3.right;
            }

            yield return null;
        }

        move.speed = 0;
        StopAllCoroutines();
        
    }

    public void InitHorMovement()
    {
        enemyAnimator.enabled = false;
        beginHorMovement = true;
    }
}
