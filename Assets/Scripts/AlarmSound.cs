using System.Collections;
using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    private const float ActiveVolumeAmount = 1;
    private const float InactiveVolumeAmount = 0;

    private float _volumeChangeDelay = 0.05f;
    private float _volumeChangeAmount = 0.01f;
    private float _targetVolume = 0f;
    private AudioSource _audioSource;
    private Coroutine _alarm;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.volume = 0;
    }

    public void SetAlarmOn()
    {
        SetTargetVolume(ActiveVolumeAmount);

        if (_alarm == null)
        {
            _alarm = StartCoroutine(ChangeAlarmVolumeToTarget());
        }
    }

    public void SetAlarmOff()
    {
        SetTargetVolume(InactiveVolumeAmount);

        if (_alarm == null)
        {
            _alarm = StartCoroutine(ChangeAlarmVolumeToTarget());
        }
    }

    private void SetTargetVolume(float targetVolume)
    {
        _targetVolume = targetVolume;
    }

    private IEnumerator ChangeAlarmVolumeToTarget()
    {
        WaitForSeconds wait = new WaitForSeconds(_volumeChangeDelay);

        if (_audioSource.volume == 0)
        {
            _audioSource.Play();
        }

        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _volumeChangeAmount);

            yield return wait;
        }

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }

        _alarm = null;
    }
}
