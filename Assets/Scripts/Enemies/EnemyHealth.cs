using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] int startingHealth = 3;

    int currentHealth;
    bool isDead = false;

    GameManager gameManager;

    void Awake()
    {
        currentHealth = startingHealth;
        gameManager = FindFirstObjectByType<GameManager>(); // ✅ 여기서 잡는 게 더 안정적
    }

    void OnEnable()
    {
        // ✅ 활성화될 때마다 등록 (스폰/풀링 모두 대응)
        gameManager?.AdjustEnemiesLeft(1);

        // 풀링/재활성 대비
        isDead = false;
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;              // ✅ 중복 데미지/중복 죽음 방지

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            isDead = true;
            gameManager?.AdjustEnemiesLeft(-1);
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        if (explosionVFX != null)
            Instantiate(explosionVFX, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}