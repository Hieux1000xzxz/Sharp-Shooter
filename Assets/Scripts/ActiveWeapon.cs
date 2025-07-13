using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{

    [SerializeField] StarterAssetsInputs starterAssetsInputs;
    [SerializeField] Animator animator;
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] Weapon currentWeapon;

    private float timeSinceLastShot = 0f;

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        HandleShoot();
    }
    private void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return ;
        if (timeSinceLastShot >= weaponSO.fireRate)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play("Shoot", 0, 0f);
            timeSinceLastShot = 0f;
        }
        if (!weaponSO.isAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }
}
