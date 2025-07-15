using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private GameObject robotExplosionVFX;
    private float currentHealth;
    private bool isDead = false;
    GameManager gameManager;
    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        currentHealth = maxHealth;
        gameManager.AdjustEnemiesLeft(1);
    }
    public void TakeDamage(float damage)
    {
        if (isDead) return;
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Current health: {currentHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        isDead = true;
        gameManager.AdjustEnemiesLeft(-1);
        Instantiate(robotExplosionVFX, transform.position, Quaternion.identity);
        Debug.Log($"{gameObject.name} has died.");
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Die();
        }
    }

}
