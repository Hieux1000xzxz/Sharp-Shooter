using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    [SerializeField] FirstPersonController playerPrefs;
    [SerializeField] NavMeshAgent agent;

    private void Update()
    {
        if (playerPrefs!= null)
        {
            agent.SetDestination(playerPrefs.transform.position);
        }
        else
        {
            Debug.LogWarning("Target not set for Robot movement.");
        }
    
    }
}
