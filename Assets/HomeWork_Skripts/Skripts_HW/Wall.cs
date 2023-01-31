using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Wall : MonoBehaviour
{
    [SerializeField] private UnityEvent _wentInEnemy;
    [SerializeField] private UnityEvent _cameOutEnemy;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _wentInEnemy?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _cameOutEnemy?.Invoke();
        }
    }
}
