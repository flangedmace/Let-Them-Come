using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _maxTemperature;
    [SerializeField] private float _coolingSpeed;
    [SerializeField] private float _reenableShootingDelay;

    public float ReenableShootingDelay => _reenableShootingDelay;

    private bool _coolingDown;

    private float _temperature;

    public event OnOverHeat OverHeat;

    public delegate void OnOverHeat();

    private void Start()
    {
        _coolingDown = true;
        _temperature = 0;
    }

    private void Update()
    {
        if (_coolingDown)
        {
            if(_temperature - _coolingSpeed * Time.deltaTime >= 0)
            {
                _temperature -= _coolingSpeed * Time.deltaTime;
            }
        }

        _slider.value = _temperature / _maxTemperature;
    }

    public void AddHeat()
    {
        _temperature++;

        if(_temperature >= _maxTemperature)
        {
            OverHeat?.Invoke();
        }
    }
}
