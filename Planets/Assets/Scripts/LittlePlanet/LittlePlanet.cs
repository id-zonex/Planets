using UnityEngine;

public class LittlePlanet : MonoBehaviour
{
    [SerializeField] private float temperature = 24;
    public float Temperature => temperature;

    [SerializeField] private ParticleSystem explosionParticle;
    public ParticleSystem ExplosionParticle => explosionParticle;
}
