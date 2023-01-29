using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(AudioSource))]
public class Alarm_Valume : MonoBehaviour
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

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(ReduceChanget(_target));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(ReduceChanget(_target));
        }
    }

    public void StopSound()
    {
        _target = 0f;

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(IncreaseChanget(_target));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(IncreaseChanget(_target));
        }
    }

    private void Update()
    {
        if (_audio.volume < _duration && _coroutine != null)
        {
            _audio.volume = 0f;
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator IncreaseChanget(float target)
    {
        var volume = _audio.volume;

        for (float i = 0; i >= target; i+=_duration)
        {
            volume = Mathf.Lerp(_audio.volume, target, _duration);
            _audio.volume = volume;
            yield return null;
        }
    }

    private IEnumerator ReduceChanget(float target)
    {
        var volume = _audio.volume;

        for (float i = 0; i <= target; i -= _duration)
        {
            volume = Mathf.Lerp(_audio.volume, target, _duration);
            _audio.volume = volume;
            yield return null;
        }
    }
}
