using System.Linq;
using Ink.Parsed;
using UnityEngine;
using UnityEngine.AI;

public class LootingSpawn : MonoBehaviour
{
    public GameObject spot1;
    public GameObject spot2;
    public GameObject spot3;
    public GameObject spot4;
    public GameObject spot1Talk;
    public GameObject spot2Talk;
    public GameObject spot3Talk;
    public GameObject spot4Talk;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SpawnRecruitedNPCS();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRecruitedNPCS()
    {
        bool hasValue = gameManager.recruitedNPC.Any();
        if (hasValue)
        {
       
            gameManager.lootSpawned = true;
            gameManager.lootName = "send_out";
        }
        else
        {
         
            gameManager.lootSpawned = false;
            gameManager.lootName = "none";
        }

        if (gameManager.recruitedNPC[0] != null)
        {
            Quaternion rotation = Quaternion.Euler(0, 90, 0);
            GameObject newNPC = Instantiate(gameManager.recruitedNPC[0], spot1.transform.position, rotation);
            Destroy(newNPC.GetComponent<NavMeshAgent>());
            Destroy(newNPC.GetComponent<Rigidbody>());
            newNPC.AddComponent<AnimeSet1>();
            spot1Talk.SetActive(true);

        }
        if (gameManager.recruitedNPC[1] != null)
        {
            Quaternion rotation = Quaternion.Euler(0, 90, 0);
            GameObject newNPC = Instantiate(gameManager.recruitedNPC[1], spot2.transform.position, rotation);
            Destroy(newNPC.GetComponent<NavMeshAgent>());
            Destroy(newNPC.GetComponent<Rigidbody>());
            newNPC.AddComponent<AnimeSet1>();
            
        }
        if (gameManager.recruitedNPC[2] != null)
        {
            Debug.Log("Spot 3: ");
            Quaternion rotation = Quaternion.Euler(0, 90, 0);
            GameObject newNPC = Instantiate(gameManager.recruitedNPC[2], spot3.transform.position, rotation);
            Destroy(newNPC.GetComponent<NavMeshAgent>());
            Destroy(newNPC.GetComponent<Rigidbody>());
            newNPC.AddComponent<AnimeSet1>();
           
        }
        if (gameManager.recruitedNPC[3] != null)
        {
            Debug.Log("Spot 4: ");
            Quaternion rotation = Quaternion.Euler(0, -90, 0);
            GameObject newNPC = Instantiate(gameManager.recruitedNPC[3], spot4.transform.position, rotation);
            Destroy(newNPC.GetComponent<NavMeshAgent>());
            Destroy(newNPC.GetComponent<Rigidbody>());
            newNPC.AddComponent<AnimeSet1>();
           
        }
    }
}
