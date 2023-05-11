using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    // Start is called before the first frame update
    private void Start()
    {
        InputKeyListener.inputKeyListener.onHasShoot += HasShoot;
    }

    // Update is called once per frame
    void HasShoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
