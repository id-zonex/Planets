using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlanetRotator : MonoBehaviour
{
    [SerializeField] private float speed = 10;

    private Vector3 _rotationDirection;
    private int GetDirection => Random.Range(-1, 1);

    private void Start()
    {
        _rotationDirection = GetRoationDirection();
    }

    private void FixedUpdate()
    {
        transform.Rotate(_rotationDirection * speed * Time.fixedDeltaTime);
    }

    private Vector3 GetRoationDirection()
    {
        return new Vector3(GetDirection, GetDirection, GetDirection);
    }
}
