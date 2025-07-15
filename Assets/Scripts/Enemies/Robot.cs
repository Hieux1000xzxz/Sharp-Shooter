using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    FirstPersonController playerPrefs;

    private void Awake()
    {
        playerPrefs = FindFirstObjectByType<FirstPersonController>();
    }
    private void Update()
    {
        if (playerPrefs!= null)
        {
            agent.SetDestination(playerPrefs.transform.position);
        }
    }
}

