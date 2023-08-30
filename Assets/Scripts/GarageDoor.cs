using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoor : MonoBehaviour
{
    bool up;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos + (Vector3.up * 3.5f), Time.deltaTime * 5);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            up = true;
        }
    }
}
