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
    private bool canInteract;
    public GameObject interactText;
    public GameObject cupPlacement;
    private GameObject interactableObject;
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
        else if (canInteract == true)
        {
            if(Input.GetKeyDown("f"))
            {
                StartInteract();
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

    private void StartInteract()
    {
        if (hasItem && heldItem.name == "Cup(Clone)" && interactableObject.name == "coffee machine")
        {
            interact = true;
            heldItem.transform.position = cupPlacement.transform.position;
            heldItem.transform.localScale -= new Vector3(.03f, .03f, .03f);
            heldItem.transform.parent = null;

        }
    }

    private void EndInteract()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Object")
        {
            canpickup = true;
            item = other.gameObject;
            pickUpText.SetActive(true);
        }

        if (other.gameObject.tag == "interactable" && heldItem.name == "Cup(Clone)")
        {
            
            interactText.SetActive(true);
            canInteract = true;
            interactableObject = other.gameObject;

        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false
       
        pickUpText.SetActive(false);
        interactText.SetActive(false);
    }

    private void DropObject()
    {
        Destroy(heldItem);
        hasItem = false;
    }
}
