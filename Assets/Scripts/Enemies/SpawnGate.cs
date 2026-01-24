using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnInterval = 5f;
    [SerializeField] Transform spawnPoint;

    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (playerHealth)
        {
            Instantiate(enemyPrefab, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spawnInterval);
            
        }
    }



}
