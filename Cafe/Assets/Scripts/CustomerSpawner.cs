using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
    public static CustomerSpawner Instance;

    public Image fadeImage; // Assign this in the Unity Inspector
    public float fadeDuration = 4f; // Duration of the fade effect
    public string nextSceneName = "FPS";

    public List<GameObject> customerTextPrefabs;
    public List<GameObject> recruitNPC;

    private int numRecNPCs = 0;
    private int maxRec = 0;



    private GameManager gameManager;




    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        maxRec = gameManager.maxRecruited;
        Debug.Log(gameManager.maxRecruited);
        
        StartCoroutine(SpawnCustomerRoutine());
        
        
    }

    // Update is called once per frame
    void Update()
    {
        numRecNPCs = gameManager.recruitedNPC.Count;
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
            GameObject newNPC = null;
            int randomCustOrNPC = 2;
            Debug.Log(randomCustOrNPC);

            switch (randomCustOrNPC)
            {
                case 0:
                    newNPC = Instantiate(npcPrefab, spawnPoint.position, Quaternion.identity);
                    break;

                case 1:
                    newNPC = Instantiate(npcPrefab, spawnPoint.position, Quaternion.identity);
                    break;

                case 2:
                   
                    Debug.Log(numRecNPCs);
                    Debug.Log(maxRec);
                    if (numRecNPCs <= maxRec)
                    {
                        newNPC = Instantiate(npcPrefab, spawnPoint.position, Quaternion.identity);
                        Debug.Log("NPC Spawned");
                        break;
                        
                    }
                    else
                    {
                        Debug.Log("NPC not Spawned");
                        goto case 3;
                    }

                case 3:
                    newNPC = Instantiate(npcPrefab, spawnPoint.position, Quaternion.identity);
                    break;

                case 4:
                    newNPC = Instantiate(npcPrefab, spawnPoint.position, Quaternion.identity);
                    break;

            }

            
            int randomOrder = Random.Range(0, 2);
            int randomCustomerText = 0;

            switch (randomOrder)
            {
                case 0:
                    newNPC.AddComponent<MatchaOrder>(); 
                    break;

                case 1:
                    newNPC.AddComponent<BrownSugarOrder>();
                    break;
            }

            switch(randomCustomerText)
            {
                case 0:
                    GameObject newChild = Instantiate(customerTextPrefabs[0], newNPC.transform);
                    newChild.transform.localPosition = Vector3.zero;
                    newChild.transform.localRotation = Quaternion.identity;
                    newChild.transform.localScale = Vector3.one;
                    break;
            }

            
            activeNPCs.Add(newNPC);
            totalSpawned++;

            
            
        }
    }

    public void RemoveNPCFromList(GameObject npc)
    {
        if (activeNPCs.Contains(npc))
        {
            activeNPCs.Remove(npc);
        }

        if (totalSpawned >= maxCustomers && activeNPCs.Count == 0)
        {
            StartCoroutine(FadeToBlackAndLoadScene());
        }
    }

    IEnumerator FadeToBlackAndLoadScene()
    {
        float elapsedTime = 0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(0, 0, 0, 1); // Fully black

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            yield return null;
        }

        fadeImage.color = endColor;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}


