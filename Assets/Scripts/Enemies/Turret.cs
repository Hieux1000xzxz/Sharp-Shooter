using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform turret;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] int damage = 1;
    private float fireRate = 2f;

    private void Start()
    {
        StartCoroutine(FireRoutine());
    }
    void Update()
    {
        turret.LookAt(playerTargetPoint);
       
    }
    IEnumerator FireRoutine()
    {
        while (playerHealth)
        {
            yield return new WaitForSeconds(fireRate);
            Fire();
        }
    }
    private void Fire()
    {
        Projectile newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position,Quaternion.identity).GetComponent<Projectile>();
        newProjectile.transform.LookAt(playerTargetPoint);
        newProjectile.Init(damage);
    }
}
