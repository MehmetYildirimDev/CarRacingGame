using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaceInfo : MonoBehaviour
{

    private NavMeshAgent agent;
    private Rigidbody PlayerCarRg;
    public double AlinanYol;

    [SerializeField] private int TourInfo;

    bool cooldownActive = false; // Cooldown süresi aktif mi?

    // Start is called before the first frame update
    void Start()
    {
        TourInfo = -1;

        if (GetComponent<NavMeshAgent>() == null)
        {
            PlayerCarRg = GetComponent<Rigidbody>();
            InvokeRepeating("YolHesaplama", 3f, 0.25f);
        }
        else
        {
            agent = GetComponent<NavMeshAgent>();
            InvokeRepeating("YolHesaplamaAi", 3f, 0.25f);
        }

    }

    private void YolHesaplamaAi()
    {
        AlinanYol += agent.velocity.magnitude;
    }

    private void YolHesaplama()
    {
        AlinanYol += PlayerCarRg.velocity.magnitude;
    }

    
    public void TourCountIncrease()
    {
        if (!cooldownActive)
        {
            TourInfo++;

            cooldownActive = true;
            StartCoroutine(Cooldown());
        }

        if (TourInfo >= RaceModeGameManager.instance.MaxTourCount)
        {
            print("Yaris bitti");

            if (this.gameObject.CompareTag("Player"))
            {
                print("Win");
            }
            else
            {
                print("Lose");
            }
        }
    }

    IEnumerator Cooldown()//geri donup girmesin diye
    {
        yield return new WaitForSeconds(RaceModeGameManager.instance.StartingPointcooldownTime);

        // Cooldown süresi bitti, tekrar artýrmaya izin ver
        cooldownActive = false;
    }
}
