using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset =
            new Vector2(0, meshRenderer.material.mainTextureOffset.y + Time.deltaTime * speed);
    }
}
