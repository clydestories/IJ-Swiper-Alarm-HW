using UnityEngine;

public class AlarmArea : MonoBehaviour
{
    [SerializeField] private AlarmSound sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Mover mover))
        {
            sound.SetAlarmOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Mover mover))
        {
            sound.SetAlarmOff();
        }
    }
}
