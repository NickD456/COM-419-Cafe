using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Number of NPCs. Will change when NPC is recruited or dies.
    private int npcCount = 0;
    private int money = 0;

    public static GameManager Instance;
    //Tells unity to not destroy the game manager object
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Add NPC when recruited. NPC type and name will be handled through tags. 
    public void AddNPC()
    {
        npcCount++;
    }

    //Sub NPC when dies or dismissed. NPC type and name will be handled through tags.
    public void SubNPC()
    {
        npcCount--;
    }

    public void GameOver()
    {

    }

    public void AddMoney(int moneyNum)
    {
        money = money + moneyNum;
    }

    public void SubMoney(int moneyNum)
    {
        money = money - moneyNum;
    }
}
