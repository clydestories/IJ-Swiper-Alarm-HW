using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private bool _isAlarmOn = false;
    private float _volumeChangeDelay = 0.05f;
    private float _volumeChangeAmount = 0.01f;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.volume = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Mover>() != null)
        {
            _isAlarmOn = true;
            StartCoroutine(TurnAlarmOn());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Mover>() != null)
        {
            _isAlarmOn = false;
            StartCoroutine(TurnAlarmOff());
        }
    }

    private IEnumerator TurnAlarmOn()
    {
        WaitForSeconds wait = new WaitForSeconds(_volumeChangeDelay);

        while (_isAlarmOn)
        {
            _audioSource.volume += _volumeChangeAmount;
            yield return wait;
        }
    }

    private IEnumerator TurnAlarmOff()
    {
        WaitForSeconds wait = new WaitForSeconds(_volumeChangeDelay);

        while (_isAlarmOn == false)
        {
            _audioSource.volume -= _volumeChangeAmount;
            yield return wait;
        }
    }
}
