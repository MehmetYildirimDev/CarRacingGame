using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPointRaceMode : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player") || other.transform.root.CompareTag("CarAi"))
        {
            other.transform.root.GetComponent<RaceInfo>().TourCountIncrease();
        }
    }
}
