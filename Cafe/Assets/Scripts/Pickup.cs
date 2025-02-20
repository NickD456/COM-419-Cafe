using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private bool canpickup;
    private bool hasItem;
    private bool interact;
    private bool canInteract;

    private GameObject item;
    private GameObject heldItem;
    private GameObject interactableObject;

    public GameObject hands;
    public GameObject pickUpText;
    public GameObject interactText;
    public GameObject cupPlacement;
    public GameObject brownSugarText;
    public GameObject milkText;
    public GameObject matchaText;
    public GameObject lidText;
    public GameObject teaText;

    private Vector3 originalItem;

    private DrinkManager drinkManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canpickup = false;    //setting both to false
        hasItem = false;
        interact = false;
        drinkManager = GameObject.Find("DrinkManager").GetComponent<DrinkManager>();
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
                else if (interact == true)
                {
                    heldItem.transform.SetParent(hands.transform);
                    heldItem.transform.position = hands.transform.position;
                    heldItem.transform.rotation = item.transform.rotation;
                    heldItem.transform.localScale = originalItem;

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
            if (drinkManager.hasTea == false)
            {
                GetTea();
            }
            else
            {
                teaText.SetActive(true);
                Invoke("HideTeaText", 2f);
                interactText.SetActive(false);
            }
        }
        if (hasItem && heldItem.name == "Cup(Clone)" && interactableObject.name == "Milk")
        {
            if (drinkManager.hasMilk == false)
            {
                GetMilk();
            }
            else
            {
                milkText.SetActive(true);
                Invoke("HideMilkText", 2f);
                interactText.SetActive(false);
            }
            
        }
        if (hasItem && heldItem.name == "Cup(Clone)" && interactableObject.name == "Burlap Sack")
        {
            if (drinkManager.hasBrownSugar == false)
            {
                GetBrownSugar();
            }
            else
            {
                brownSugarText.SetActive(true);
                Invoke("HideBrownSugarText", 2f);
                interactText.SetActive(false);
            }
            
        }
        if (hasItem && heldItem.name == "Cup(Clone)" && interactableObject.name == "Matcha")
        {
            if (drinkManager.hasMatcha == false)
            {
                GetMatcha();
            }
            else
            {
                matchaText.SetActive(true);
                Invoke("HideMatchaText", 2f);
                interactText.SetActive(false);
            }
            
        }
        if (hasItem && heldItem.name == "Cup(Clone)" && interactableObject.name == "Cup Lid")
        {
            if (drinkManager.hasLid == false)
            {
                GetLid();
            }
            else
            {
                lidText.SetActive(true);
                Invoke("HideLidText", 2f);
                interactText.SetActive(false);
            }
           
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

    private void GetTea()
    {
            interact = true;
            heldItem.transform.position = cupPlacement.transform.position;
            originalItem = heldItem.transform.localScale;
            heldItem.transform.localScale -= new Vector3(.03f, .03f, .03f);

            heldItem.transform.parent = null;


            interactText.SetActive(false);
            drinkManager.SetTea();

            canInteract = false;
        
    }

    private void GetBrownSugar()
    {
        drinkManager.SetBrownSugar();
    }
    private void GetMilk()
    {
        drinkManager.SetMilk();

        Transform child = heldItem.transform.Find("Milk liq");
        child.gameObject.SetActive(true);
    }
    private void GetMatcha()
    {
        drinkManager.SetMatcha();
    }
    private void GetLid()
    {
        drinkManager.SetLid();
        Transform child = heldItem.transform.Find("Lid");
        child.gameObject.SetActive(true);
    }

    private void HideTeaText()
    {
        teaText.SetActive(false);
    }
    void HideMilkText()
    {
        milkText.SetActive(false);
    }
    void HideLidText()
    {
        lidText.SetActive(false);
        
    }
    void HideBrownSugarText()
    {
        brownSugarText.SetActive(false);
    }
    void HideMatchaText()
    {
        matchaText.SetActive(false);
    }
}
