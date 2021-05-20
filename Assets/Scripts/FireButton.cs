using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour
{
    public event OnButtonDown ButtonDown;
    public event OnButtonUp ButtonUp;

    public delegate void OnButtonDown();
    public delegate void OnButtonUp();

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        ButtonDown?.Invoke();
    }

    private void OnMouseUp()
    {
        ButtonUp?.Invoke();
    }
}
