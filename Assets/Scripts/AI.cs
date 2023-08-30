using UnityEngine.AI;
using UnityEngine;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void Update()
    {
        agent.SetDestination(player.transform.position);
    }

}
