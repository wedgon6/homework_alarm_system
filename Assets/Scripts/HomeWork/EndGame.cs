using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached = new UnityEvent();
    private bool _isReached;
    public event UnityAction Reached
    {
        add => _reached.AddListener(value);
        remove => _reached.RemoveListener(value);
    }

    public bool IsReached { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsReached)
            return;
        
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            IsReached = true;
            _reached.Invoke();
        }
    }
}
