using System.Collections;
using UnityEngine;

public class LittlePlanetSpawner : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;

    [SerializeField] private float minTime = 2;
    [SerializeField] private float maxTime = 3;

    [SerializeField] private LittlePlanet[] littlePlanets;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            SpawnPlanet();
        }
    }

    private void SpawnPlanet()
    {
        int randMassive = Random.Range(0, littlePlanets.Length);

        Transform newObj = Instantiate(littlePlanets[randMassive], GetSpawnPosition(), Quaternion.identity).transform;
        newObj.SetParent(transform);
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
