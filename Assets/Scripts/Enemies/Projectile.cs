using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject hitVFX;
    int damage;
    void Update()
    {
        rb.linearVelocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(damage);
        Instantiate(hitVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void Init(int damage)
    {
        this.damage = damage;
    }
}

