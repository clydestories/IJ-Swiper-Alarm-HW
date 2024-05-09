using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Vertical);

        _rigidbody.velocity = transform.forward * direction * _speed * Time.fixedDeltaTime;
    }
}
