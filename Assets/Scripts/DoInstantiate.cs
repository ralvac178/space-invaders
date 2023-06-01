using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private GameObject instanceBox;

    private void Start()
    {
        instanceBox = GameObject.Find("Instances"); 
    }
    public void LetsInstantiate()
    {
        GameObject instance = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        if (instanceBox!=null)
        {
            instance.transform.parent = instanceBox.gameObject.transform;
        }
        
    }
}
