using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spannInterval = 2f;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private PlayerHealth playerHealth;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    IEnumerator SpawnRoutine()
    {
        while (playerHealth)
        {
            Instantiate(enemyPrefab, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spannInterval);
        }
    }
}
