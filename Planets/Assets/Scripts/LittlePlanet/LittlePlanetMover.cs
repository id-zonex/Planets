using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LittlePlanetMover : MonoBehaviour
{
    public float Speed = 100;

    private Rigidbody _rb;
    private Vector3 _direction;

    private void Start()
    {
        _direction = (FindObjectOfType<PlanetsRotator>().transform.position - transform.position).normalized;

        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(_direction);
    }

    public void Move(Vector3 direction)
    {
        _rb.velocity = direction * Speed * Time.fixedDeltaTime;
    }
}

