using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float animationSpeed = 1.0f;
    [SerializeField] private Color damageColor;
    [SerializeField] private Vector3 damageScale;
    private float animProgress;
    private Color defaultColor;
    private Vector3 defaultScale;


    private void Awake()
    {
        defaultColor = spriteRenderer.color;
        defaultScale = transform.localScale;
    }

    private void Update()
    {
        if (animProgress > 0)
        {
            spriteRenderer.color = Color.Lerp(defaultColor, damageColor, animProgress);
            transform.localScale = Vector3.Lerp(defaultScale, damageScale, animProgress);
            animProgress = Mathf.Clamp(animProgress - animationSpeed * Time.deltaTime, 0, 1);
        }
    }

    public void StartAnimation()
    {
        animProgress = 1;
    }
}
