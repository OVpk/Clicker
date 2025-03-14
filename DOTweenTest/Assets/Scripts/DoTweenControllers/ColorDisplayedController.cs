using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ColorDisplayedController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Grow()
    {
        transform.DOScale(transform.localScale/2 * 1.2f, 0.25f);
        spriteRenderer.DOFade(0.5f, 0.25f).OnComplete(
            () =>
            {
                transform.DOScale(new Vector3(9f,5f,1f), 0.25f);
                spriteRenderer.DOFade(1f, 0.25f);
            }
        );
    }
}
