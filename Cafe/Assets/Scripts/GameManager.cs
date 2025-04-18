using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //Number of NPCs. Will change when NPC is recruited or dies.
    private int npcCount = 0;
    public int money = 0;
    public List<GameObject> npcArray;
    public List<GameObject> recruitedNPC;   
    public int dayNum = 1;
    private GameManager gameManager;
    public TMP_Text DayNum;
    private NightEnd nightend;
    private ZombieSpawn zombieSpawn;
    public bool isTalking = false;
    public bool canEnter = false;
    public bool canTalk = true;
    public bool turnBack = false;
    public bool isRecruit = false;
    public int maxRecruited = 13;
    public string KeyName;
    public bool isPaused = false;
    public bool sentLoot = false;
    public bool lootSpawned = false;
    public string lootName;
    public bool destroyTalk = false;
    public bool destroyCust = false;
    public int lootedMoney;
    public string oldString;
    public bool doorClose = true;
    public bool firstDay = false;
    public bool letInfectIn = false;
    public bool hasGun = false;
    public bool shooting = false;






    public static GameManager Instance;
    //Tells unity to not destroy the game manager object
    private void Awake()
    {
                nightend = GameObject.Find("NightEnd").GetComponent<NightEnd>();

        doorClose = true;
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        DayNum.text = "Day Num: " + dayNum;
        DayNum.enabled = true;
        destroyCust = false;
        firstDay = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nightend.zombieCount == 0)
        {
            DayNum.enabled = false;
        }

       

    }

    //Add NPC when recruited. NPC type and name will be handled through tags. 
    public void AddNPC(int npcNumber)
    {
        if (npcCount < 4)
        {
            switch (npcCount) 
            {
                case 0:
                    recruitedNPC[0] = npcArray[npcNumber];
                    break;
                case 1:
                    recruitedNPC[1] = npcArray[npcNumber];
                    break;
                case 2:
                    recruitedNPC[2] = npcArray[npcNumber];
                    break;
                case 3:
                    recruitedNPC[3] = npcArray[npcNumber];
                    break;
                default:
                    break;

            }
            npcCount++;
        }
        else
        {
            Debug.Log("to many npc");
        }




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

    public void OnDeath()
    {
        recruitedNPC.RemoveAt(0);
    }
}
