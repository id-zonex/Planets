using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Planet : MonoBehaviour
{
    public Action Death;
    public Action<float> ChangeTemperature;

    [SerializeField] private PlanetType planetType;
     
    [SerializeField] private Planet secondPlanet;

    [Header("Temperature Settings")]
    [SerializeField] private float temperature = 24;
    [SerializeField] private float scaleCoefficient = 1000;

    [Header("Melting")]
    [SerializeField] private float meltDelay = 0.1f;
    [SerializeField] private float temperatureCoefficient = 1000;

    public float Temperature => temperature;

    private void Start()
    {
        Death += OnDeath;

        StartCoroutine(Melting());
    }

    private void OnCollisionEnter(Collision collision)
    {
        LittlePlanet planet = collision.gameObject.GetComponent<LittlePlanet>();
        CheckPlanet(planet);
    }

    private IEnumerator Melting()
    {
        while (true)
        {
            Melt();
            yield return new WaitForSeconds(meltDelay);
        }
    }

    private void Melt()
    {
        if (secondPlanet == null) return;

        AddTemperature(secondPlanet.Temperature / temperatureCoefficient);
    }

    private void CheckPlanet(LittlePlanet planet)
    {
        if (planet == null) return;

        AddTemperature(planet.Temperature);
        Destroy(planet.gameObject);
    }

    private void AddTemperature(float temperature)
    {
        this.temperature += temperature;

        ChangeSize(temperature);
        CheckOnDeath();

        ChangeTemperature?.Invoke(this.temperature);
    }

    private void CheckOnDeath()
    {
        if (temperature * (int)planetType <= 0)
            Death?.Invoke();
    }

    private void ChangeSize(float temperature)
    {
        float size = temperature / scaleCoefficient;

        transform.localScale += new Vector3(size, size, size) * (int)planetType;
    }

    private void OnDeath()
    {
        Debug.Log("I Death");
        Destroy(gameObject);
    }
}
