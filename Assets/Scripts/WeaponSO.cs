using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "ScriptableObjects/Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header("Weapon Settings")]
    public int damage = 15;
    public float fireRate = 0.5f;
    public GameObject hitVFX;
    public GameObject weaponPrefab;
    public bool isAutomatic = false;
    public bool canZoom = false;
    public float zoomAmount = 10f;
    public int magazineSize = 12;

}
