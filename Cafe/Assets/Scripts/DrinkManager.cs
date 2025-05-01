using UnityEngine;

public class DrinkManager : MonoBehaviour
{

    public static DrinkManager Instance;

    public bool hasTea;
    public bool hasBrownSugar;
    public bool hasMatcha;
    public bool hasMilk;
    public bool hasLid;
    public bool hasRad;
    public bool hasHoney;
    public bool orderComp;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasLid = false;
        hasMatcha = false;
        hasBrownSugar = false;
        hasMilk = false;
        hasTea = false;
        orderComp = false;
        hasRad = false;
        hasHoney = false;
        Instance = this;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (gameManager.dayNum > 10)
        {
            gameManager.money -= 30;
        }
        else if (gameManager.dayNum > 4)
        {
            gameManager.money -= 20;
        }
        else if (gameManager.dayNum > 1)
        {
            gameManager.money -= 10;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTea()
    {
        hasTea = true;
    }

    public void SetBrownSugar()
    {
        hasBrownSugar = true;
    }

    public void SetMatcha()
    {
        hasMatcha = true;
    }

    public void SetMilk()
    {
        hasMilk = true;
    }

    public void SetLid()
    {
        hasLid = true;
    }

    public void SetRad()
    {
        hasRad = true;
    }
    public void SetHoney()
    {
        hasHoney = true;
    }

    public void ResetDrinkState()
    {
        hasLid = false;
        hasMatcha= false;
        hasBrownSugar= false;
        hasMilk= false;
        hasTea= false;
        hasRad = false;
        hasHoney = false;
        orderComp = false;
        gameManager.turnBack = false;
        gameManager.isRecruit = false; 
        gameManager.canEnter = false;
        gameManager.canTalk = true;
        gameManager.isTalking = false;
        Debug.Log("Reset on: " + gameObject.name);
    }

    public void setOrder()
    {
        orderComp = true;
        gameManager.canEnter = false;
    }
}
