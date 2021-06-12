using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LittlePlanetMover : MonoBehaviour
{
    [SerializeField] private float speed = 100f;

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
        _rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
}

