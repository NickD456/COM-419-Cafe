using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomerSpawner : MonoBehaviour
{

    public GameObject npcPrefab; 
    public Transform spawnPoint; 
    public float spawnInterval = 5f; 
    public int maxCustomers = 5;
    public int maxNPCsOnMap = 2; 
    public int resumeSpawnThreshold = 2;
    private int totalSpawned = 0; 
    private List<GameObject> activeNPCs = new List<GameObject>();

    


    void Start()
    {
        StartCoroutine(SpawnCustomerRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCustomerRoutine()
    {
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

    void SpawnCustomer()
    {
        if (totalSpawned < maxCustomers)
        {
            GameObject newNPC = Instantiate(npcPrefab, spawnPoint.position, Quaternion.identity);
            int randomOrder = Random.Range(0, 2);

            switch (randomOrder)
            {
                case 0:
                    newNPC.AddComponent<MatchaOrder>(); 
                    break;

                case 1:
                    newNPC.AddComponent<BrownSugarOrder>();
                    break;
            }
            activeNPCs.Add(newNPC);
            totalSpawned++;

            
            
        }
    }

    void RemoveNPCFromList(GameObject npc)
    {
        if (activeNPCs.Contains(npc))
        {
            activeNPCs.Remove(npc);
        }
    }
}
