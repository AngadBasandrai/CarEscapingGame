using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{

    public GameObject bubble;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", Random.Range(0.25f, 2f));
    }

    // Update is called once per frame
    void Spawn()
    {
        GameObject b = Instantiate(bubble);
        b.transform.parent = transform;
        b.transform.localPosition = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(0.2f, 1.4f), 0);
        float variable = Random.Range(0.25f, 0.5f)/1.25f;
        b.transform.localScale = new Vector3(variable, variable, variable);
        b.transform.eulerAngles = new Vector3(-90, 0, 0);
        Invoke("Spawn", Random.Range(1f, 4f));
    }
}
