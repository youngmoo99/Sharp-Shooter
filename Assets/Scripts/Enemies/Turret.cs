using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float fireRate = 2f;

    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(FireRoutine());
    }

    void Update()
    {
        turretHead.LookAt(playerTargetPoint);
    }

    IEnumerator FireRoutine()
    {
        while (playerTargetPoint)
        {
            yield return new WaitForSeconds(fireRate);
            Instantiate(projectilePrefab, projectileSpawnPoint.position, turretHead.rotation);
        }
    }
}
