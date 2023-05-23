using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTankScript : MonoBehaviour
{
    [SerializeField]private AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.CompareTag("Player"))
        {
            CarOnTrigger();
        }
    }

    public void CarOnTrigger()
    {
        print("Benzin Alindi");
        Destroy(this.gameObject);

        FuelModeManager.instance.GetFuel();
        SoundManager.instance.PlaySound(audioClip);
    }

}
