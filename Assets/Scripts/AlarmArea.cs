using UnityEngine;

public class AlarmArea : MonoBehaviour
{
    private const float _ActiveVolumeAmount = 1;
    private const float _InactiveVolumeAmount = 0;

    [SerializeField] private AlarmSound sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Mover>() != null)
        {
            sound.SetTargetVolume(_ActiveVolumeAmount);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Mover>() != null)
        {
            sound.SetTargetVolume(_InactiveVolumeAmount);
        }
    }
}
