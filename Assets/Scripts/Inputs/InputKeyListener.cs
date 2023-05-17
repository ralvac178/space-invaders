using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyListener : MonoBehaviour, IShootable, IMovable
{

    ////Singleton
    //public static InputKeyListener inputKeyListener;

    //public delegate void HasShoot();
    //public event HasShoot onHasShoot;

    //private void Awake()
    //{
    //    inputKeyListener = this;
    //}

    public void Shoot()
    {
        InputProvider.Shoot();
    }

    public void Move(Vector3 direction)
    {
        InputProvider.Move(direction);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            Shoot();
        }

        Move(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0));
    }
}
