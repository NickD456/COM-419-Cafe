using UnityEngine;

public class DrinkManager : MonoBehaviour
{

    public static DrinkManager Instance;

    public bool hasTea;
    public bool hasBrownSugar;
    public bool hasMatcha;
    public bool hasMilk;
    public bool hasLid;
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

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

    public void Reset()
    {
        hasLid = false;
        hasMatcha= false;
        hasBrownSugar= false;
        hasMilk= false;
        hasTea= false;
        orderComp = false;
        gameManager.turnBack = false;
        gameManager.isRecruit = false; 
        gameManager.canEnter = false;
        gameManager.canTalk = true;
        gameManager.isTalking = false;
    }

    public void setOrder()
    {
        orderComp = true;
        gameManager.canEnter = false;
    }
}
