using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PurpleEnemy : Enemy
{
    protected override void Die()
    {
        transform.DOScaleY(transform.localScale.y / 2, 0.5f);
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.5f);

        _spriteRenderer.DOFade(0, 1);
    }
}
