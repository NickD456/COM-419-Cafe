using UnityEngine;
using UnityEngine.AI;

public class NavScript : MonoBehaviour
{
  
    private NavMeshAgent agent;
    private GameObject orderSpot;
    private GameObject end;
    private GameObject doorSpot;
    private GameObject recruitSpot;
    private CustomerSpawner customerSpawner;
    private static DrinkManager drinkManager;
    private GameManager gameManager;
    private Animator anim1;


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
        customerSpawner = GameObject.Find("Customer Spawner").GetComponent<CustomerSpawner>();

        anim1 = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.stoppingDistance = 0.4f;

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
        

        if(agent.remainingDistance <= 0.4f)
        {
            anim1.SetBool("Walk", false);
        }
        else
        {
            
            anim1.SetBool("Walk", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "End Spot")
        {
            Destroy(this.gameObject);
            customerSpawner.RemoveNPCFromList(this.gameObject);
            drinkManager.Reset();
        }
        if (other.gameObject.tag == "Recruit Spot")
        {
            
            customerSpawner.RemoveNPCFromList(this.gameObject);
            gameManager.npcArray[0] = this.gameObject;

            Destroy(this.gameObject);

            drinkManager.Reset();
        }
    }


}
