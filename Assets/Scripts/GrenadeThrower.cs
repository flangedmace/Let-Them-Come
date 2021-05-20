using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private int _grenades;
    [SerializeField] private TextMeshProUGUI _grenadesCount;
    [SerializeField] private Grenade _grenadeTemplate;
    [SerializeField] private float _clickDelay;


    private Camera _camera;
    private float _clicked;
    private Coroutine _setClicked;

    private void Start()
    {
        _clicked = 0;

        _camera = Camera.main;

        SetGrenadesUI();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _clicked++;
        }

        if (_clicked == 1) 
        {
            _setClicked = StartCoroutine(SetClicked(0));
        }
        else if (_clicked > 1)
        {
            _clicked = 0;

            StopCoroutine(_setClicked);

            if(_grenades > 0)
            {
                ThrowGrenade();
            }
        }
    }

    private void ThrowGrenade()
    {
        Vector2 target = _camera.ScreenToWorldPoint(Input.mousePosition);

        Grenade grenage = Instantiate(_grenadeTemplate, transform.position, new Quaternion(0, 0, 0, 0));

        grenage.Init(target);

        _grenades--;

        SetGrenadesUI();
    }

    private IEnumerator SetClicked(int clicked)
    {
        yield return new WaitForSeconds(_clickDelay);

        _clicked = clicked;
    }

    private void SetGrenadesUI()
    {
        _grenadesCount.text = Convert.ToString(_grenades);
    }
}
