using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Wall : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarmStart;
    [SerializeField] private UnityEvent _alarmStop;

    private bool _isPlaying = false;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _isPlaying = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _isPlaying = false;
        }
    }

    private void Update()
    {

        if (_isPlaying)
        {
            _alarmStart?.Invoke();

        }
        else
        {
            _alarmStop?.Invoke();
        }
    }
}
