using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _minAngle;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector2 mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (mouseWorldPosition - (Vector2)transform.position).normalized;

        transform.up = direction;

        float currentAngle = transform.localEulerAngles.z;

        if (currentAngle >= _maxAngle && currentAngle <= 180)
        {
            transform.Rotate(0, 0, _maxAngle - currentAngle);
        }
        else if (currentAngle <= _minAngle && currentAngle >= 180)
        {
            transform.Rotate(0, 0, _minAngle - currentAngle);
        }
    }
}
