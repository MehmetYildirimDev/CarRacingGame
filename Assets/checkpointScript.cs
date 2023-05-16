using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.CompareTag("CarAi"))
        {
            
        }
        print("calisiyor");
    }
}
