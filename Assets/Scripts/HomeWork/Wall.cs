using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Wall : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _duration;

    private float _runningTime;
    private bool _isPlaying;
    private float _target;
    private float _volumeScale;

    private void Start()
    {
        _audio.volume = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audio.Play();
        _isPlaying = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isPlaying = false;
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;
        _volumeScale =  _runningTime / _duration;

        if (_isPlaying)
        {
            _target = 1f;
        }
        else
        {
            _target = 0f;
        }

        _audio.volume = Mathf.Lerp(_audio.volume, _target, _volumeScale);
    }
}
