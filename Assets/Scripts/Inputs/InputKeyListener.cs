using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyListener : MonoBehaviour, IShootable
{

    //Singleton
    public static InputKeyListener inputKeyListener;

    public delegate void HasShoot();
    public event HasShoot onHasShoot;

    private void Awake()
    {
        inputKeyListener = this;
    }

    public void Shoot()
    {
        onHasShoot();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            Debug.Log("Shoot");
            Shoot();
        }
    }
}
