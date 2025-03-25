using UnityEngine;
using UnityEngine.AI;

public class NavScript : MonoBehaviour
{
  
    private NavMeshAgent agent;
    private GameObject orderSpot;
    private GameObject end;
    private GameObject doorSpot;
    private static DrinkManager drinkManager;
    private GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        orderSpot = GameObject.FindWithTag("Line Spot");
        end = GameObject.FindWithTag("End Spot");
        doorSpot = GameObject.FindWithTag("Door Spot");
        drinkManager = GameObject.Find("DrinkManager").GetComponent<DrinkManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (drinkManager.orderComp == true)
        {
            agent.destination = end.transform.position;
        }
        if (gameManager.canEnter == false)
        {
            agent.destination = doorSpot.transform.position;
        }
        else
        {
            agent.destination = orderSpot.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
