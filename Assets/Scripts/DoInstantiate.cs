using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public void LetsInstantiate()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
