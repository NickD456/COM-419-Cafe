using UnityEngine;

public class BrownSugarOrder : MonoBehaviour
{
    private bool correctOrder;
    private DrinkManager drinkManager;
    private CustomerSpawner customerSpawner;
    private Transform child;
    private bool orderTaken;
   private Transform brownSugarChild;
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
            brownSugarChild = transform.Find("Brown Sugar Order Text");
            if (brownSugarChild != null && !ordered)
            {
                brownSugarChild.gameObject.SetActive(true);
                ordered = true;
            }
        }

        

    }

    void CheckOrder()
    {
        if (drinkManager.hasLid && drinkManager.hasMilk && drinkManager.hasBrownSugar && drinkManager.hasTea)
        {
            correctOrder = true;
            drinkManager.Reset();
            Debug.Log("order right");
            child = null;
            
            orderTaken = true;
            Transform orderRight = transform.Find("Order Right ");
            if (orderRight != null)
            {
                orderRight.gameObject.SetActive(true);
                brownSugarChild.gameObject.SetActive(false);
            }
            drinkManager.setOrder();
        }
    
        else
        {
            Debug.Log("order wrong");
            correctOrder = false;
            drinkManager.Reset();
            child = null;
           
            orderTaken = true;
            Transform orderWrong = transform.Find("Order Wrong Text");
            if (orderWrong != null)
            {
                orderWrong.gameObject.SetActive(true);
                brownSugarChild.gameObject.SetActive(false);
            }
            drinkManager.setOrder();
        }
    }
}
