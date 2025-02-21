using UnityEngine;

public class BrownSugarOrder : MonoBehaviour
{
    private bool correctOrder;
    private DrinkManager drinkManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drinkManager = GameObject.Find("DrinkManager").GetComponent<DrinkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform child = transform.Find("Cup(Clone)");
        if (child != null)
        {
            CheckOrder();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Line Spot")
        {
            Transform brownSugarChild = transform.Find("Brown Sugar Order Text");
            if (brownSugarChild != null)
            {
                brownSugarChild.gameObject.SetActive(true);
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
        }
        else
        {
            Debug.Log("order wrong");
            correctOrder = false;
            drinkManager.Reset();
        }
    }
}
