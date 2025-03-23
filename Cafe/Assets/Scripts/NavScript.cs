using UnityEngine;
using UnityEngine.AI;

public class NavScript : MonoBehaviour
{
  
    private NavMeshAgent agent;
    private GameObject orderSpot;
    private GameObject end;
    private GameObject doorSpot;
    private static DrinkManager drinkManager;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        orderSpot = GameObject.FindWithTag("Line Spot");
        end = GameObject.FindWithTag("End Spot");
        doorSpot = GameObject.FindWithTag("Door Spot");
        drinkManager = GameObject.Find("DrinkManager").GetComponent<DrinkManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (drinkManager.orderComp == true)
        {
            agent.destination = end.transform.position;
        }
        else if(drinkManager.orderComp == false)
        {
            agent.destination = orderSpot.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
