using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _shotInterval;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private TemperatureBar _temperatureBar;

    private bool _ableToShoot = true;
    private bool _overHeat = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(_overHeat == false)
            {
                if (_ableToShoot)
                {
                    Shoot();
                }
            }
        }
    }

    private void OnEnable()
    {
        _temperatureBar.OverHeat += DisableShooting;

    }

    private void OnDisable()
    {
        _temperatureBar.OverHeat -= DisableShooting;

    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(_bulletTemplate, _shootPoint.position, transform.rotation);
        bullet.Init(_shootPoint.position - transform.position);

        _temperatureBar.AddHeat();

        _ableToShoot = false;

        StartCoroutine(EnableNextShot());
    }

    private IEnumerator EnableNextShot()
    {
        yield return new WaitForSeconds(_shotInterval);

        _ableToShoot = true;
    }
    
    private IEnumerator EnableShooting()
    {
        yield return new WaitForSeconds(_temperatureBar.ReenableShootingDelay);

        _overHeat = false;
    }

    private void DisableShooting()
    {
        _overHeat = true;
        StartCoroutine(EnableShooting());
    }
}
