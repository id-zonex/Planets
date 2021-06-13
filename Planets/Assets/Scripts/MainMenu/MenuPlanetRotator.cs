using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlanetRotator : MonoBehaviour
{
    [SerializeField] private float speed = 10;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * speed * Time.fixedDeltaTime, Space.Self);
    }
}
