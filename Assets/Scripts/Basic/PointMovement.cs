using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currnetPoint;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0;i<_path.childCount;i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currnetPoint];
 
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            _currnetPoint++;

            if(_currnetPoint >= _points.Length)
            {
                _currnetPoint = 0;
            }
        }
    }
}
