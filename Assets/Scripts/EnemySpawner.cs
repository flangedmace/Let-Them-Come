using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private float _spawnInterval;

    private bool _ableToShoot = false;

    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    private void Update()
    {
        if (_ableToShoot)
        {
            Instantiate(_enemyTemplate, new Vector3(Random.Range(-2.3f, 2.3f), 6f), new Quaternion(0, 0, 0, 0));
            _ableToShoot = false;
            StartCoroutine(EnableSpawning());
        }
    }

    private IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(2f);
        _ableToShoot = true;
    }

    private IEnumerator EnableSpawning()
    {
        yield return new WaitForSeconds(_spawnInterval);
        _ableToShoot = true;
    }
}
