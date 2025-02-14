using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    bool canpickup;
    bool hasItem;
    public GameObject hands;
    private GameObject item;
    private GameObject heldItem;
    public GameObject pickUpText;
    private bool interact;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canpickup = false;    //setting both to false
        hasItem = false;
        interact = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canpickup == true) // if you enter thecollider of the objecct
        {
            if (Input.GetKeyDown("e"))
            {
                if (!hasItem)
                {
                    heldItem = Instantiate(item, hands.transform.position, Quaternion.identity);
                    heldItem.transform.SetParent(hands.transform);
                    heldItem.transform.rotation = item.transform.rotation;
                    hasItem = true;
                }

               

            }
        }
        else 
        {
            if (Input.GetKeyDown("e"))
            {
                if (hasItem && !interact)
                {
                    DropObject();
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Object")
        {
            canpickup = true;
            item = other.gameObject;
            Debug.Log("entered");
            pickUpText.SetActive(true);
        }

        if (other.gameObject.tag == "machine")
        {
            interact = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false
        interact = false;
        pickUpText.SetActive(false);
    }

    private void DropObject()
    {
        Destroy(heldItem);
        hasItem = false;
    }
}
