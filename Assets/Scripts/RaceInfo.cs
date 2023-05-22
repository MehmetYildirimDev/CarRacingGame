using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaceInfo : MonoBehaviour
{
    public string LabelName;

    private NavMeshAgent agent;
    private Rigidbody playerCarRb;
    public double AlinanYol;

    [SerializeField] private int TourInfo;

    bool cooldownActive = false; // Cooldown süresi aktif mi?


    public Color TextColor;

    void Start()
    {
        TourInfo = 0;

        if (GetComponent<NavMeshAgent>() == null)
        {
            playerCarRb = GetComponent<Rigidbody>();
            //InvokeRepeating("YolHesaplama", 3f, 0.1f);
        }
        else
        {
            agent = GetComponent<NavMeshAgent>();
            //InvokeRepeating("YolHesaplamaAi", 3f, 0.1f);
        }

    }

    //private void YolHesaplamaAi()
    //{
    //    print(this.gameObject.name + ": " + agent.velocity.magnitude);
    //    AlinanYol += agent.velocity.magnitude;
    //}

    //private void YolHesaplama()
    //{
    //    print(this.gameObject.name + ": " + playerCarRb.velocity.magnitude);
    //    AlinanYol += playerCarRb.velocity.magnitude;
    //}

    private void Update()
    {
        if (agent == null)
        {
            AlinanYol += playerCarRb.velocity.magnitude;
        }
        else
        {
            AlinanYol += agent.velocity.magnitude;
        }
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
                RaceModeGameManager.instance.GameWin();
            }
            else
            {
                print("Lose");
                RaceModeGameManager.instance.GameOver();
            }
        }
    }

    IEnumerator Cooldown()//geri donup girmesin diye
    {
        yield return new WaitForSeconds(RaceModeGameManager.instance.StartingPointcooldownTime);

        // Cooldown süresi bitti, tekrar artýrmaya izin ver
        cooldownActive = false;
    }

    public int GetTourCount()
    {
        return TourInfo;
    }
}
