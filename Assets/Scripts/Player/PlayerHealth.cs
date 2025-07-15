using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] private float maxHealth = 5;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBars;
    [SerializeField] GameObject gameOverContainer;
    [SerializeField] GameObject inGameUI;
    [SerializeField] StarterAssetsInputs starterAssetsInputs;
    private float currentHealth;
    private bool isDead = false;
    private int GameOverPriority = 20;
    private void Start()
    {
        currentHealth = maxHealth;
        AdjustShieldUI();
    }
    public void TakeDamage(float damage)
    {
        if (isDead) return;
        currentHealth -= damage;
        AdjustShieldUI();
        Debug.Log($"{gameObject.name} took {damage} damage. Current health: {currentHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        isDead = true;
        gameOverContainer.SetActive(true);
        inGameUI.SetActive(false);
        starterAssetsInputs.SetCursorState(false);
        weaponCamera.parent = null;
        deathVirtualCamera.Priority = GameOverPriority;
        Debug.Log($"{gameObject.name} has died.");
        Destroy(gameObject);
    }

    public void AdjustShieldUI()
    {
        for(int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealth)
            {
                shieldBars[i].enabled = true;
            }
            else
            {
                shieldBars[i].enabled = false;
            }
        }
    }
}
