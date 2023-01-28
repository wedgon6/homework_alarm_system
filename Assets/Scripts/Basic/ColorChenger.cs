using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChenger : MonoBehaviour
{
    private SpriteRenderer Target;
    [SerializeField] private float _duration;

    [SerializeField] private Color _targetColor;
    private float _runningTime;
    private Color _stertColor;

    private void Start()
    {
        Target = GetComponent<SpriteRenderer>();
        _stertColor = Target.color;
    }

    void Update()
    {
        if(_runningTime <= _duration)
        {
            _runningTime += Time.deltaTime;
            float normalazziRunnTime = _runningTime / _duration;
           
            Target.color = Color.Lerp(_stertColor, _targetColor, normalazziRunnTime);
        }
    }
}
