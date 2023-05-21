using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScriptForFuelMode : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.CompareTag("Player"))
        {
            FuelModeManager.instance.GameWin();
        }
    }
}
