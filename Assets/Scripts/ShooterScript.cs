using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    // Update is called once per frame
    public void HasShoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
