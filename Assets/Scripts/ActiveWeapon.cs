using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{

    [SerializeField] StarterAssetsInputs starterAssetsInputs;
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] Animator animator;
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] WeaponSO defaultWeaponSO;
    [SerializeField] Weapon currentWeapon;
    [SerializeField] GameObject zoomVingette;
    [SerializeField] TMP_Text ammoText;
    private float timeSinceLastShot = 0f;
    private float defaultFOV;
    private float currentAmmo;

    private void Awake()
    {
        defaultFOV = cinemachineVirtualCamera.m_Lens.FieldOfView;
    }
    private void Start()
    {
        SwitchWeapon(defaultWeaponSO);
        AjustAmmo(weaponSO.magazineSize);
    }
    public void AjustAmmo(int amount){
        currentAmmo += amount;
        if(currentAmmo > weaponSO.magazineSize)
        {
            currentAmmo = weaponSO.magazineSize;
        }
        ammoText.text = currentAmmo.ToString();
    }
    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        HandleShoot();
        HandleZoom();
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }
        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = weaponSO;
        AjustAmmo(weaponSO.magazineSize);
    }
    private void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return ;
        if (timeSinceLastShot >= weaponSO.fireRate && currentAmmo > 0)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play("Shoot", 0, 0f);
            timeSinceLastShot = 0f;
            AjustAmmo(-1);
        }
        if (!weaponSO.isAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }

    private void HandleZoom()
    {
        if (!weaponSO.canZoom) return;
        if (starterAssetsInputs.zoom)
        {
            cinemachineVirtualCamera.m_Lens.FieldOfView = weaponSO.zoomAmount;
            zoomVingette.SetActive(true);
        }
        else
        {
            cinemachineVirtualCamera.m_Lens.FieldOfView = defaultFOV;
            zoomVingette.SetActive(false);

        }
    }
}
