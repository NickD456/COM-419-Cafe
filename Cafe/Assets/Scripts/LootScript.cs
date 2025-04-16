using UnityEngine;

public class LootScript : MonoBehaviour
{
    bool lootedToday;
    private GameManager gameManager;
 
    int deathChance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.money += gameManager.lootedMoney;
        gameManager.lootedMoney = 0;
        lootedToday = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.recruitedNPC.Count != 0)
        {
            if (!lootedToday)
            {
                SendLooting();
            }
        }
    }

    void SendLooting()
    {

        if(gameManager.sentLoot)
        { 
            deathChance = Random.Range(1, 20);
            if (deathChance == 1)
            {
                gameManager.OnDeath();
            }
            gameManager.lootedMoney = Random.Range(10, 35);

            

            Debug.Log("Looted: " + gameManager.lootedMoney);

            lootedToday = true;
            gameManager.sentLoot = false;
            gameManager.KeyName = gameManager.oldString;
        }
    }
}
