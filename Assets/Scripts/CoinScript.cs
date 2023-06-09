using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.CompareTag("Player"))
        {
            FuelModeManager.instance.GetCoin();
            Destroy(this.gameObject);
            SoundManager.instance.PlaySound(audioClip);
        }
    }
}
