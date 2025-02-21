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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drinkManager = GameObject.Find("DrinkManager").GetComponent<DrinkManager>();
        orderTaken = false;
        ordered = false;
        customerSpawner = GameObject.Find("Customer Spawner").GetComponent<CustomerSpawner>();
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

        if(other.gameObject.tag == "End Spot")
        {
            Destroy(this.gameObject);
            customerSpawner.RemoveNPCFromList(this.gameObject);
            drinkManager.Reset();
        }

        
    }


    void CheckOrder()
    {
        if (drinkManager.hasLid && drinkManager.hasMilk && drinkManager.hasMatcha && drinkManager.hasTea)
        {
            correctOrder = true;
            drinkManager.Reset();
            Debug.Log("order right");
            child = null;
            GetComponent<Renderer>().material.color = Color.green;
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
            drinkManager.Reset();
            child = null;
            GetComponent<Renderer>().material.color = Color.red;
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
