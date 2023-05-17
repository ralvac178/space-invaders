using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDestroy : MonoBehaviour
{
    //private GameObject triggerObject;
    public void DestroyObject()
    {
        //bool canDestroy = triggerObject != null ? true : false;
        //if (canDestroy)
        //{
        //    Destroy(triggerObject);
        //}

        Destroy(gameObject);
    }
}
