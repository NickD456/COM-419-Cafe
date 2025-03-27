using UnityEngine;
using UnityEngine.AI;

public class NavScript : MonoBehaviour
{
  
    private NavMeshAgent agent;
    private GameObject orderSpot;
    private GameObject end;
    private GameObject doorSpot;
    private GameObject recruitSpot;
    private static DrinkManager drinkManager;
    private GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        orderSpot = GameObject.FindWithTag("Line Spot");
        end = GameObject.FindWithTag("End Spot");
        doorSpot = GameObject.FindWithTag("Door Spot");
        recruitSpot = GameObject.FindWithTag("Recruit Spot");
        drinkManager = GameObject.Find("DrinkManager").GetComponent<DrinkManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (drinkManager.orderComp == true || gameManager.turnBack == true)
        {
            agent.destination = end.transform.position;
        }
        else if (gameManager.canEnter == false && drinkManager.orderComp == false)
        {
            agent.destination = doorSpot.transform.position;
        }
        else if (gameManager.canEnter == true && drinkManager.orderComp == false)
        {
            agent.destination = orderSpot.transform.position;
        }
        
        if (gameManager.isRecruit == true)
        {
            agent.destination = recruitSpot.transform.position;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
