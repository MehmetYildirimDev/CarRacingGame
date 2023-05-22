using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarDriverAi : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] checkpoints;
    public float distance;
    public const float OFFSETDISTANCE = 10f;
    public int index;



    void Start()
    {
        StartCoroutine(StartCountDown());
        index = 0;
        agent = GetComponent<NavMeshAgent>();
    }




    IEnumerator StartCountDown()
    {

        GetComponent<CarDriverAi>().enabled = false;

        float kalanSure = RaceModeGameManager.instance.StartingTime;

        while (kalanSure > 0)
        {
            yield return new WaitForSeconds(1f);
            kalanSure--;
        }

        GetComponent<CarDriverAi>().enabled = true;

        agent.SetDestination(checkpoints[index].position);
        // Geri sayým tamamlandýktan sonra yapýlacak iþlemleri buraya ekleyebilirsiniz
    }


    void Update()
    {

        distance = Vector3.Distance(transform.position, checkpoints[index].position);
        if (distance < OFFSETDISTANCE)
        {

            if (index < checkpoints.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            agent.SetDestination(checkpoints[index].position);
        }

    }


}
