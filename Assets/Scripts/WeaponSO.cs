using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "ScriptableObjects/Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header("Weapon Settings")]
    public int damage = 15;
    public float fireRate = 0.5f;
    public GameObject hitVFX;
    public bool isAutomatic = false;


}
