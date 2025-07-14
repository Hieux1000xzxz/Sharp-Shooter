using UnityEngine;

public class AmorrPickup : Pickup
{
    [SerializeField] int ammoAmount = 10;
    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
         activeWeapon.AjustAmmo(ammoAmount);
    }
}
