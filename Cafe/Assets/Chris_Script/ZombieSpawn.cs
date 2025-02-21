using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ZombieSpawn : MonoBehaviour
{
    public GameObject ZombiePrefab;
    public Transform zombieSpawn;
    private GameManager gameManager;
    private NightEnd nightend;

    public GameObject npcPrefab;
    public Transform spawnPoint;
    public float spawnInterval;
    public int maxCustomers;
    public int maxNPCsOnMap;
    public int resumeSpawnThreshold;
    private int totalSpawned;
    private List<GameObject> activeNPCs = new List<GameObject>();
    public static CustomerSpawner Instance;

    void Awake()
    {

        Instantiate(ZombiePrefab, zombieSpawn.position, Quaternion.identity);


        nightend = GameObject.Find("NightEnd").GetComponent<NightEnd>();


        nightend.zombieCount += 1;
        Debug.Log(nightend.zombieCount);

       



        

        
      
    

    }

    private void Update()
    {
        StartCoroutine(SpawnCustomerRoutine());
    }

    IEnumerator SpawnCustomerRoutine()
    {
        Debug.Log("wotk");
        while (totalSpawned < maxCustomers)
        {
            
            // Wait if max NPCs are on the map
            while (activeNPCs.Count >= maxNPCsOnMap)
            {
                yield return new WaitUntil(() => activeNPCs.Count < resumeSpawnThreshold);
            }

            // Spawn a new NPC
            SpawnCustomer();
            yield return new WaitForSeconds(spawnInterval);
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
        if (totalSpawned < maxCustomers)
        {
            GameObject newNPC = Instantiate(ZombiePrefab, zombieSpawn.position, Quaternion.identity);

            activeNPCs.Add(newNPC);
            totalSpawned++;
            nightend.zombieCount += 1;
        }
    }
}
