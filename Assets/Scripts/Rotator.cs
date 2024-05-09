using UnityEngine;

public class Rotator : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _rotationSpeed;

    private float _rotationDirection;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        _rotationDirection = Input.GetAxis(Horizontal);
        transform.Rotate(Vector3.up, _rotationDirection * _rotationSpeed * Time.deltaTime);
    }
}
