using UnityEngine.AI;
using UnityEngine;

public class SentryAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public Material mat;
    public Material mat2;
    public MeshRenderer r;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void Update()
    {

        if (Vector3.Distance(transform.position, player.transform.position) < 6)
        {
            agent.speed = 6.5f;
            r.sharedMaterial = mat;
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.speed = 2;
            r.sharedMaterial = mat2;
            agent.SetDestination(player.transform.position);
        }
    }
}
