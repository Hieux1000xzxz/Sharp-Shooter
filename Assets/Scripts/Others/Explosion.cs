using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 5f;
    private void Start()
    {
       Explode();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in hitColliders)
        {
            PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();
            if (!playerHealth) continue;
            playerHealth.TakeDamage(1);
            break;
        }
    }
}

