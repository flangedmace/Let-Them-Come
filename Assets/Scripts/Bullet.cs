using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage;

    [SerializeField] private Collider2D _collider;

    [SerializeField] private GameObject _bulletEffect;
    [SerializeField] private GameObject _explosionEffect;

    private bool _moving = true;
    private Vector2 _direction;

    public void Init(Vector2 direction)
    {
        _direction = direction;
    }

    private void Start()
    {
        StartCoroutine(SelfDestroy());
    }

    private void Update()
    {
        if (_moving)
        {
            transform.position += (Vector3)_direction.normalized * _speed * Time.deltaTime;
        }
    }

    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(_lifeTime);

        Destroy(gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);

            _bulletEffect.SetActive(false);
            _explosionEffect.SetActive(true);

            _collider.enabled = false;

            _moving = false;
        }
    }
}
