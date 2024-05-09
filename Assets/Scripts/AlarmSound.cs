using System.Collections;
using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    private float _volumeChangeDelay = 0.05f;
    private float _volumeChangeAmount = 0.01f;
    private float _targetVolume = 0f;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.volume = 0;
        StartCoroutine(ChangeAlarmVolumeToTarget());
    }

    public void SetTargetVolume(float targetVolume)
    {
        _targetVolume = targetVolume;
    }

    private IEnumerator ChangeAlarmVolumeToTarget()
    {
        WaitForSeconds wait = new WaitForSeconds(_volumeChangeDelay);

        while (enabled)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _volumeChangeAmount);
            yield return wait;
        }
    }
}
