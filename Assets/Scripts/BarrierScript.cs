using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.transform.root.CompareTag("Player"))
        {
            print("Oyuncu Bariyere Carpti");
        }
    }
}
