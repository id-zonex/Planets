using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Planet : MonoBehaviour
{
    public Action Death;
    public Action<float> ChangeTemperature;

    [Header("Planet Settings")]
    [SerializeField] private PlanetType planetType; 
    [SerializeField] private Planet secondPlanet;

    [Header("Temperature Settings")]
    [SerializeField] private float temperature = 24;
    [SerializeField] private float scaleCoefficient = 1000;

    [Header("Melting Settings")]
    [SerializeField] private float meltDelay = 0.1f;
    [SerializeField] private float temperatureCoefficient = 1000;

    public float Temperature => temperature;

    private void Start()
    {
        Time.timeScale = 1;

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

        CreateExplosion(planet.transform.position, planet.ExplosionParticle);

        AddTemperature(planet.Temperature);
        Destroy(planet.gameObject);
    }

    private void AddTemperature(float temperature)
    {
        this.temperature += temperature;

        ChangeSize(temperature);

        ChangeTemperature?.Invoke(this.temperature);

        CheckOnDeath();
    }

    private void CheckOnDeath()
    {
        if (temperature * (int)planetType < 0)
            Death?.Invoke();
    }

    private void ChangeSize(float temperature)
    {
        float size = temperature / scaleCoefficient;

        transform.localScale += new Vector3(size, size, size) * (int)planetType;
    }

    private void CreateExplosion(Vector3 contactPoint, ParticleSystem explosion)
    {
        Vector3 direction = transform.position - contactPoint;
        Transform particle = Instantiate(explosion, contactPoint, Quaternion.identity, null).transform;

        particle.localRotation = Quaternion.LookRotation(-direction);
    }

    private void OnDeath()
    {
        Debug.Log("I Death");
        Destroy(gameObject);
    }
}
