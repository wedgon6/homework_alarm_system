using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(AudioSource))]
public class AlarmValume : MonoBehaviour
{
    [SerializeField] private float _duration;

    private AudioSource _audio;
    private float _target;
    private Coroutine _coroutine;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }

    public void PlaySound()
    {
        _target = 1f;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        
        _coroutine = StartCoroutine(VolumeChanget(_target));
     
    }

    public void StopSound()
    {
        _target = 0f;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        
        _coroutine = StartCoroutine(VolumeChanget(_target));
    }

    private IEnumerator VolumeChanget(float target)
    {
        while(_audio.volume != target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, target, _duration);
            yield return new WaitForFixedUpdate();
        }
    }
}
