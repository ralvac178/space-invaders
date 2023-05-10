using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundaries
{
    public float xMin, xMax, yMin, yMax;
}
public class PlayerMover : MonoBehaviour
{
    [SerializeField] Move moveScript;
    [SerializeField] float speed;
    public Boundaries boundaries;
    // Start is called before the first frame update
    void Start()
    {
        moveScript.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        moveScript.direction = direction;

        float xPos = Mathf.Clamp(transform.position.x, boundaries.xMin, boundaries.xMax);
        float yPos = Mathf.Clamp(transform.position.y, boundaries.yMin, boundaries.yMax);

        transform.position = new Vector2(xPos, yPos);
    }
}
