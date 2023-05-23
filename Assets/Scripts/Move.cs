using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    [SerializeField] private bool takeParentDirection = false;
    private void Start()
    {
        if (takeParentDirection)
        {
            GameObject shooter = GameObject.Find("ShooterFighter");
            if (shooter != null)
            {
                direction = Quaternion.Euler(shooter.transform.rotation.eulerAngles) *Vector3.up;
            }            
        }
    }
    public void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.Self);
    }
}
