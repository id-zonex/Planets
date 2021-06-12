using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Planet : MonoBehaviour
{
    [SerializeField] private float temperature;
    [SerializeField] private float scaleCoefficient;

    public float Temperature => temperature;

    private SphereCollider _sphereCollider;

    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void AddTemperature(float temperature)
    {
        this.temperature += temperature;
    }

    private void ChangeSize(float temperature)
    {
        _sphereCollider.radius += temperature / scaleCoefficient;
    }
}
