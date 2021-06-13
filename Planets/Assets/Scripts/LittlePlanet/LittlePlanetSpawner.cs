using System.Collections;
using UnityEngine;

public class LittlePlanetSpawner : MonoBehaviour
{
    [Header("Borders")]
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;

    [Header("Time")]
    [SerializeField] private AnimationCurve  minTime;
    [SerializeField] private AnimationCurve  maxTime;

    [Header("")]
    [SerializeField] private AnimationCurve smallPlanetSpeed;
    [SerializeField] private LittlePlanetMover[] littlePlanets;

    private float _time;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private void Update()
    {
        _time += Time.deltaTime;
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime.Evaluate(_time), maxTime.Evaluate(_time)));
            SpawnPlanet();
        }
    }

    private void SpawnPlanet()
    {
        int randMassive = Random.Range(0, littlePlanets.Length);

        LittlePlanetMover newObj = Instantiate(littlePlanets[randMassive], GetSpawnPosition(), Quaternion.identity);

        newObj.Speed = smallPlanetSpeed.Evaluate(_time);

        newObj.transform.SetParent(transform);
    }

    private Vector3 GetSpawnPosition()
    {
        int rand = Random.Range(0, 4);

        if (rand == 0)
            return new Vector3(startPosition.position.x, -10, Random.Range(startPosition.position.z, -startPosition.position.z));

        else if (rand == 1)
            return new Vector3(Random.Range(startPosition.position.x, endPosition.position.x), -10, startPosition.position.z);

        else if (rand == 2)
            return -new Vector3(startPosition.position.x, 10, Random.Range(startPosition.position.z, -startPosition.position.z));

        else if (rand == 3)
            return -new Vector3(Random.Range(startPosition.position.x, endPosition.position.x), 10, startPosition.position.z);

        return Vector3.zero;
    }
}
