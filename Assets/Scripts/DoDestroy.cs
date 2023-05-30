using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDestroy : MonoBehaviour
{
    //private GameObject triggerObject;
    public void DestroyObject()
    {
        if (transform.tag.Equals("Boss"))
        {
            StartCoroutine(Wait());
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.45f);
        Destroy(gameObject);
        StopCoroutine(Wait());
    }
}
