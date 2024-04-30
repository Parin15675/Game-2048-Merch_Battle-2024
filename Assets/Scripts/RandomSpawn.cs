using System.Collections;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] heroPrefabs; // Array of hero prefabs
    [SerializeField] private RectTransform spawnArea; // The RectTransform area where heroes can spawn
    [SerializeField] private float spawnInterval = 2.0f; // Time between spawns
    [SerializeField] private float minSpawnY = -50f; // Minimum Y position for spawning
    [SerializeField] private float maxSpawnY = 50f; // Maximum Y position for spawning

    private void Start()
    {
        StartCoroutine(HeroSpawnRoutine());
    }

    IEnumerator HeroSpawnRoutine()
    {
        while (true)
        {
            SpawnHero();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnHero()
    {
        // Random position within the spawn area boundaries
        float x = Random.Range(spawnArea.rect.min.x, spawnArea.rect.max.x);
        float y = Random.Range(minSpawnY, maxSpawnY);
        Vector2 spawnPosition = new Vector2(x, y);

        // Instantiate a random hero prefab at the random position within the spawn area
        GameObject newHero = Instantiate(heroPrefabs[Random.Range(0, heroPrefabs.Length)], spawnArea);
        newHero.GetComponent<RectTransform>().anchoredPosition = spawnPosition;
        newHero.transform.localScale = Vector3.one; // Ensure the scale is set correctly
    }
}
