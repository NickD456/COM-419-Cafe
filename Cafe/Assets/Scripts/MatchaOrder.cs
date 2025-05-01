using UnityEngine;

public class MatchaOrder : MonoBehaviour
{
    private bool correctOrder;
    private DrinkManager drinkManager;
    private CustomerSpawner customerSpawner;
    private Transform child;
    private bool orderTaken;
    private Transform matchaChild;
    private bool ordered;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drinkManager = GameObject.Find("DrinkManager").GetComponent<DrinkManager>();
        orderTaken = false;
        ordered = false;
        customerSpawner = GameObject.Find("Customer Spawner").GetComponent<CustomerSpawner>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        child = transform.Find("Cup(Clone)");
        if (child != null && !orderTaken)
        {
            CheckOrder();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Line Spot")
        {
            matchaChild = transform.Find("Matcha Order Text");
            if (matchaChild != null && !ordered)
            {
                matchaChild.gameObject.SetActive(true);
                ordered = true;
            }
        }

        

        
    }


    void CheckOrder()
    {
        if (drinkManager.hasLid && drinkManager.hasMilk && drinkManager.hasMatcha && drinkManager.hasTea)
        {
            correctOrder = true;
            
            Debug.Log("order right");
            child = null;
            gameManager.AddMoney(7);
            orderTaken = true;
            Transform orderRight = transform.Find("Order Right ");
            if (orderRight != null)
            {
                orderRight.gameObject.SetActive(true);
                matchaChild.gameObject.SetActive(false);
            }
            drinkManager.setOrder();
        }
        else 
        {
            Debug.Log("order wrong");
            correctOrder = false;
            
            child = null;
            gameManager.SubMoney(5);
            orderTaken = true;
            Transform orderWrong = transform.Find("Order Wrong Text");
            if (orderWrong != null)
            {
                orderWrong.gameObject.SetActive(true);
                matchaChild.gameObject.SetActive(false);
            }
            drinkManager.setOrder();
        }
    }
}
