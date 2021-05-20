using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float _timeToExplode;
    [SerializeField] private int _damage;
    [SerializeField] private float _hitRadius;
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private float _afterExplosionLifeTime;

    [Header("Components")]
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Vector2 _target;

    public void Init(Vector2 target)
    {
        _target = target;
    }

    private void Start()
    {
        transform.DOMove(_target, _timeToExplode);

        _animator.speed = 1 / _timeToExplode;

        StartCoroutine(BlowUp());
    }

    private IEnumerator BlowUp()
    {
        yield return new WaitForSeconds(_timeToExplode);

        _animator.speed = 0;
        _spriteRenderer.enabled = false;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _hitRadius);

        foreach(Collider2D hitCollider in hitColliders)
        {
            if(hitCollider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
            }
        }

        Instantiate(_explosionEffect, transform);

        StartCoroutine(SelfDestroy());
    }

    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(_afterExplosionLifeTime);

        Destroy(gameObject);
    }
}
