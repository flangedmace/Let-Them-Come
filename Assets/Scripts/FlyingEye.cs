using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyingEye : Enemy
{
    [SerializeField] private Animator _animator;

    private const string _deathAnimationName = "Death";

    protected override void Die()
    {
        _animator.Play(_deathAnimationName);

        _spriteRenderer.DOFade(0, 1.5f);
    }
}
