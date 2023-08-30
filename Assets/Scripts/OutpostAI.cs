using UnityEngine.AI;
using UnityEngine;

public class OutpostAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public Material mat;
    public Material mat2;
    public bool moving;
    public Vector3 origPos;
    public MeshRenderer r;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        origPos = transform.position;
    }

    private void Update()
    {

        if (!moving)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 7)
            {
                agent.speed = 5f;
                moving = true;
                r.sharedMaterial = mat;
                agent.SetDestination(player.transform.position);
            }
        }

        else
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 7)
            {
                agent.speed = 5f;
                moving = true;
                r.sharedMaterial = mat;
                agent.SetDestination(player.transform.position);
            }
            else
            {
                moving = false;
                r.sharedMaterial = mat2;
                agent.SetDestination(origPos);
            }
        }
    }
}
