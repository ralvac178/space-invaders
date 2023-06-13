using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    public bool isEnable = true;

    // Update is called once per frame
    public void HasShoot()
    {
        if (isEnable)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);

        }       
    }

    public void EnableShoot(bool enableValue)
    {
        isEnable = enableValue;
    }
}
