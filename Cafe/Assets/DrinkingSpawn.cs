using System.Collections.Generic;
using UnityEngine;

public class DrinkingSpawn : MonoBehaviour
{
    public List<GameObject> sit = new List<GameObject>();
    private GameManager gameManager;
    private  static DrinkManager drinkManager;
    private CustomerSpawner customerSpawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drinkManager = GameObject.Find("DrinkManager").GetComponent<DrinkManager>();
        customerSpawner = GameObject.Find("Customer Spawner").GetComponent<CustomerSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       
        customerSpawner.RemoveNPCFromList(other.gameObject);
      
        

        if (drinkManager.orderComp)
        {
            Debug.Log("Order Completed");
            if (other.name == "Ch01_nonPBR(Clone)")
            {
                sit[0].SetActive(true);
                
            }
            else if (other.name == "Ch06_nonPBR(Clone)")
            {
                sit[1].SetActive(true);
                
            }
        
            else if (other.name == "Ch21_nonPBR(Clone)")
            {
                sit[3].SetActive(true);
                
            }
            else if (other.name == "Ch22_nonPBR(Clone)")
            {
                sit[4].SetActive(true);
                
            }
           
            else if (other.name == "Ch41_nonPBR(Clone)")
            {
                sit[6].SetActive(true);
               
            }
        } 
        drinkManager.ResetDrinkState();
        Destroy(other.gameObject);
    }

}
