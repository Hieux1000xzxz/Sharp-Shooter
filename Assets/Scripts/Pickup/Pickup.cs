using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] ActiveWeapon activeWeapon;
    [SerializeField] float rotationSpeed = 50f;

    private void Update()
    {
        RotatePickup();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPickup(activeWeapon);
            Destroy(gameObject);
        }
    }
    private void RotatePickup()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime,0f);
    }
    protected abstract void OnPickup(ActiveWeapon activeWeapon);
   
}

