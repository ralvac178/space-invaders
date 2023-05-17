using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    // Start is called before the first frame update
    private void Start()
    {
        if (transform.parent.gameObject.transform.parent.gameObject.tag.Equals("Player"))
        {
            InputProvider.OnHasShoot += HasShoot;
        }
    }

    // Update is called once per frame
    public void HasShoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        InputProvider.OnHasShoot -= HasShoot;
    }
}
