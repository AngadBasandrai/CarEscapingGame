using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSphere : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.up * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "End")
        {
            Destroy(gameObject);
        }
    }
}
