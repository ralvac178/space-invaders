using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public void LetsInstantiate()
    {
        Debug.Log("Hit");
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}