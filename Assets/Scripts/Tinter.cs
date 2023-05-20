using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tinter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Color originalColor;
    public Color tintColor;

    [SerializeField] private float timeBackColor;

    // Start is called before the first frame update
    void Awake()
    {
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    public void Tint()
    {
        spriteRenderer.color = tintColor;
        Invoke(nameof(ComeBackColor), timeBackColor);
    }

    public void ComeBackColor()
    {
        spriteRenderer.color = originalColor;
    }
}
