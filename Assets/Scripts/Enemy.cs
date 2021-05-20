using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private float _lifeTime;
    [SerializeField] private Collider2D _collider;
    [SerializeField] protected SpriteRenderer _spriteRenderer;

    private bool _alive = true;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Die();

            _collider.enabled = false;
            _alive = false;
        }
    }

    private void Start()
    {
        StartCoroutine(SelfDestroy());
    }

    private void Update()
    {
        if (_alive)
        {
            transform.position += new Vector3(0, -_speed, 0) * Time.deltaTime;
        }
    }

    protected virtual void Die() {   }

    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(_lifeTime);

        Destroy(gameObject);
    }
}
