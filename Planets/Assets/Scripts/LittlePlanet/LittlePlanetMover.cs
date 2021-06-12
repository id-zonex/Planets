using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LittlePlanetMover : MonoBehaviour
{
    public float speed = 100f;
    public Rigidbody rb;
    public Vector3 Movement;

    private void Start()
    {
        Movement = (FindObjectOfType<PlanetsRotator>().transform.position - transform.position).normalized;

        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(Movement);
    }

    public void Move(Vector3 direction)
    {
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
}

