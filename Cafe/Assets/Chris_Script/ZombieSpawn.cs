using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class ZombieSpawn : MonoBehaviour
{
    public GameObject ZombiePrefab;
    //public Transform zombieSpawn;
    private GameManager gameManager;
    private NightEnd nightend;

    public GameObject npcPrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;

    public float spawnInterval;
    public int maxCustomers;
    public int maxNPCsOnMap;
    public int resumeSpawnThreshold;
    private int totalSpawned;
    private List<GameObject> activeNPCs = new List<GameObject>();
    public static CustomerSpawner Instance;
    public TMP_Text ZombCount;
    public bool hasRun = false;
    //Random rdm = new Random();
    public int rand1;


    void Awake()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Instantiate(ZombiePrefab, zombieSpawn.position, Quaternion.identity);


        nightend = GameObject.Find("NightEnd").GetComponent<NightEnd>();


        //nightend.zombieCount += 1;
        StartCoroutine(SpawnCustomerRoutine());
        ZombCount.enabled = true;

    }

    private void Update()
    {

        ZombCount.text = "Zomb: " + nightend.zombieCount;
        if(nightend.zombieCount == 0 )        
        {
            ZombCount.enabled = false;
        }
        rand1 = Random.Range(1,4);

    }

    IEnumerator SpawnCustomerRoutine()
    {
        //while (totalSpawned < maxCustomers)
        for(int i=0; i < (2*(gameManager.dayNum)); i++)
        {
          //  Debug.Log(gameManager.dayNum + "Day");
           // Debug.Log(nightend.zombieCount + "Zomb");
    
            
            // Wait if max NPCs are on the map
            while (activeNPCs.Count >= maxNPCsOnMap)
            {
                yield return new WaitUntil(() => activeNPCs.Count < resumeSpawnThreshold);
            }

            // Spawn a new NPC   
            yield return new WaitForSeconds(spawnInterval);
            SpawnCustomer();
         
         }

    }

    public void RemoveNPCFromList(GameObject npc)
    {
        if (activeNPCs.Contains(npc))
        {
            activeNPCs.Remove(npc);
            nightend.zombieCount -= 1;
        }

       
    }

    void SpawnCustomer()
    {
        //if (totalSpawned < maxCustomers)
        //{
        hasRun = true;

        if(rand1 == 1){
            GameObject newNPC = Instantiate(ZombiePrefab, spawnPoint1.position, Quaternion.identity);
                        activeNPCs.Add(newNPC);
                        Debug.Log("Spawn1");

        }
        if(rand1 == 2){
            GameObject newNPC = Instantiate(ZombiePrefab, spawnPoint2.position, Quaternion.identity);
                        activeNPCs.Add(newNPC);
                        Debug.Log("Spawn2");


        }
        if(rand1 == 3){
            GameObject newNPC = Instantiate(ZombiePrefab, spawnPoint3.position, Quaternion.identity);
                        activeNPCs.Add(newNPC);
                        Debug.Log("Spawn3");    

        }
    

            //activeNPCs.Add(newNPC);
            //totalSpawned++;
            nightend.zombieCount += 1;
        //}
    }
}
