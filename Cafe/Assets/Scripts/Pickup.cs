using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private bool canpickup;
    private bool hasItem;
    private bool interact;
    private bool canInteract;
    private bool canGive;
    private bool isBook;

    private GameObject item;
    private GameObject heldItem;
    private GameObject interactableObject;
    private GameObject customerHands;
    private GameObject customer;
    private GameObject custItem;

    public GameObject hands;
    public GameObject pickUpText;
    public GameObject interactText;
    public GameObject cupPlacement;
    public GameObject brownSugarText;
    public GameObject milkText;
    public GameObject matchaText;
    public GameObject radText;
    public GameObject honeyText;
    public GameObject lidText;
    public GameObject teaText;
    public GameObject GiveText;
    public GameObject bookText;
    public GameObject bookBrownSugar;
    public GameObject bookMatcha;
    public GameObject bookRad;
    public GameObject bookHoney;
    public GameObject trashText;
    public bool canDrop = false;    

    public AudioClip milksound;
    AudioSource milks;
    public AudioClip machasound;
    AudioSource matchas;
    public AudioClip booksound;
    AudioSource books;

    private Vector3 originalItem;

    private static DrinkManager drinkManager;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canpickup = false;    //setting both to false
        hasItem = false;
        interact = false;
        isBook = false;
        drinkManager = GameObject.Find("DrinkManager").GetComponent<DrinkManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        milks = gameObject.AddComponent<AudioSource>();
        matchas = gameObject.AddComponent<AudioSource>();
        books = gameObject.AddComponent<AudioSource>();

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

        else if (isBook == true)
        {
            if(Input.GetKeyDown("f"))
            {
                FlipPage();
            }
        }
        else if (canDrop == true)
        {
            if (Input.GetKeyDown("e"))
            {
                DropObject();
            }
        }
        if (canGive)
        {
            if(Input.GetKeyDown("r"))
            {
                GiveDrink();
            }
        }
        Debug.Log(drinkManager.orderComp);

        if (customerHands == null)
        {
            customerHands = GameObject.FindWithTag("CustomerHands");
            customer = GameObject.FindWithTag("Customer");
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
        if (hasItem && heldItem.name == "Cup(Clone)" && interactableObject.name == "RadJar")
        {
            if (drinkManager.hasRad == false)
            {
                GetRad();
            }
            else
            {
                radText.SetActive(true);
                Invoke("HideRadText", 2f);
                interactText.SetActive(false);
            }

        }
        if (hasItem && heldItem.name == "Cup(Clone)" && interactableObject.name == "Honey Jar")
        {
            if (drinkManager.hasHoney == false)
            {
                GetHoney();
            }
            else
            {
                honeyText.SetActive(true);
                Invoke("HideHoneyText", 2f);
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

        if(other.gameObject.tag == "Customer" && heldItem.name == "Cup(Clone)")
        {
            GiveText.SetActive(true);
            canGive = true;
        }

        if(other.gameObject.tag == "trash" && heldItem.name == "Cup(Clone)")
        {
            trashText.SetActive(true);
            canDrop = true;
            
        }

        if ((other.gameObject.tag == "Book"))
        {
            isBook = true;
            bookText.SetActive(true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false

        pickUpText.SetActive(false);
        interactText.SetActive(false);
        canInteract = false;
        GiveText.SetActive(false);
        isBook = false;
        bookText.SetActive(false);
        trashText.SetActive(false);
        canDrop = false;
        canGive = false;

    }

    private void DropObject()
    {
        Destroy(heldItem);
        hasItem = false;
        gameManager.SubMoney(5);
        drinkManager.ResetDrinkState();
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
        Debug.Log(drinkManager.hasTea);

        canInteract = false;
        milks.PlayOneShot(milksound);

    }

    private void GetBrownSugar()
    {
        drinkManager.SetBrownSugar();
        Debug.Log(drinkManager.hasBrownSugar);
    }
    private void GetMilk()
    {
        drinkManager.SetMilk();

        Transform child = heldItem.transform.Find("Milk liq");
        child.gameObject.SetActive(true);
        Debug.Log(drinkManager.hasMilk);
        
    }
    private void GetMatcha()
    {
        drinkManager.SetMatcha();
        Debug.Log(drinkManager.hasMatcha);
        matchas.clip = machasound;
        matchas.Play();
    }
    private void GetRad()
    {
        drinkManager.SetRad();
        Debug.Log(drinkManager.hasRad);
    }
    private void GetHoney()
    {
        drinkManager.SetHoney();
        Debug.Log(drinkManager.hasHoney);
    }
    private void GetLid()
    {
        drinkManager.SetLid();
        Transform child = heldItem.transform.Find("Lid");
        child.gameObject.SetActive(true);
        Debug.Log(drinkManager.hasLid);
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
    void HideRadText()
    {
        radText.SetActive(false);
    }
    void HideHoneyText()
    {
        honeyText.SetActive(false);
    }

    void GiveDrink()
    {
        heldItem.transform.SetParent(customer.transform);
        heldItem.transform.position = customerHands.transform.position;
        GiveText.SetActive(false);
        hasItem = false;
        heldItem = custItem;
        Destroy(heldItem);
        heldItem = null;
        customer = null;
    }

    void FlipPage()
    {
        Debug.Log("work");
        if(bookBrownSugar.activeSelf)
        {
            bookBrownSugar.SetActive(false);
            bookMatcha.SetActive(true);
            Debug.Log("matcah");
        }

        else if (bookMatcha.activeSelf)
        {
            bookMatcha.SetActive(false);
            bookHoney.SetActive(true);
            Debug.Log("sugar");
        }
        else if (bookRad.activeSelf)
        {
            bookRad.SetActive(false);
            bookBrownSugar.SetActive(true);
            Debug.Log("honey");
        }
        else if (bookHoney.activeSelf)
        {
            bookHoney.SetActive(false);
            bookRad.SetActive(true);
            Debug.Log("rad");
        }
        
            books.clip = booksound;
        books.Play();
    }
}
