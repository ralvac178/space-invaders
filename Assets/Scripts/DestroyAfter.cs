using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 10f);
    }
}
