using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayStop : MonoBehaviour
{
    [SerializeField] private float _durationVolume;

    private AudioSource _audioSource;
    private bool _isWork;
    private float _runningTime;
    private float _initialValue;
    private float _lastValue;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        _isWork = true;
        _initialValue = 0;
        _lastValue = 1;
    }

    public void StopAudio()
    {
        _isWork = true;
        _initialValue = 1;
        _lastValue = 0;
    }

    private void Update()
    {
        if (_isWork)
        {
            if (_audioSource.volume != _lastValue)
            {
                _runningTime += Time.deltaTime;
                _audioSource.volume = Mathf.Lerp(_initialValue, _lastValue, (_runningTime / _durationVolume));
            }
            else
            {
                _isWork = false;
                _runningTime = 0;
            }
        }
        else
        {
            return;
        }
    }
}