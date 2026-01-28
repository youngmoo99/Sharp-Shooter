using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] int startingHealth = 3;

    int currentHealth;
    bool isDead = false;

    GameManager gameManager;
    bool registered = false;

    void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnEnable()
    {
        // Enable이 여러 번 되어도 +1 중복 방지
        if (!registered)
        {
            gameManager?.AdjustEnemiesLeft(1);
            registered = true;
        }

        // 재활성/스폰 대비
        isDead = false;
        currentHealth = startingHealth;
    }

    void OnDisable()
    {
        // Disable/Destroy될 때 반드시 -1 (중복 방지)
        if (registered)
        {
            gameManager?.AdjustEnemiesLeft(-1);
            registered = false;
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            isDead = true;
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        if (explosionVFX != null)
            Instantiate(explosionVFX, transform.position, Quaternion.identity);

        Destroy(gameObject); // Destroy되면 OnDisable 호출됨 → -1 처리
    }
}