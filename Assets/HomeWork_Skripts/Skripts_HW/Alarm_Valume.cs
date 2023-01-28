using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Alarm_Valume : MonoBehaviour
{
    [SerializeField] private float _duration;
    private AudioSource _audio;

    private bool _isPlaying;
    private float _target;
    private Coroutine _coroutine;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }

    public void PlaySound()
    {
        _isPlaying = true;
        _target = 1f;

        _coroutine = StartCoroutine(VolumeChanget());
    }

    public void StopSound()
    {
        _isPlaying = false;
        _target = 0f;
        _coroutine = StartCoroutine(VolumeChanget());
    }

    private void Update()
    {
        if (_audio.volume < _duration && _coroutine != null)
        {
            _audio.volume = 0f;
            StopCoroutine(_coroutine);
        }
    }

    public void StartAlarm()
    {
        StartCoroutine(VolumeChanget());
    }

    private IEnumerator VolumeChanget()
    {
        if (_isPlaying)
        {
            _target = 1f;
        }
        else
        {
            _target = 0f;
        }

        _audio.volume = Mathf.Lerp(_audio.volume, _target, _duration);

        yield return null;
    }
}
