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
    public int maxCustomers = 3;
    public int maxNPCsOnMap = 2; 
    public int resumeSpawnThreshold = 2;
    private int totalSpawned = 0; 
    private List<GameObject> activeNPCs = new List<GameObject>();
    public static CustomerSpawner Instance;

    public Image fadeImage; // Assign this in the Unity Inspector
    public float fadeDuration = 4f; // Duration of the fade effect
    public string nextSceneName = "FPS";

    public List<GameObject> customerTextPrefabs;
    public List <GameObject> recruitTextPrefabs;
    public List<GameObject> recruitNPC = new List<GameObject>();
    public List<GameObject> customerNPC = new List<GameObject>();
    public List<GameObject> infectNPC = new List<GameObject>();

    private int numRecNPCs = 0;
    private int maxRec = 0;



    private GameManager gameManager;




    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        maxRec = gameManager.maxRecruited;
        Debug.Log(gameManager.maxRecruited);

        maxCustomers = maxCustomers + gameManager.dayNum;
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
            int randomCustOrNPC = Random.Range(0, 8);
          
            int randomInfect = Random.Range(0, 10);
           






            switch (randomCustOrNPC)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    if (randomInfect == 0)
                    {
                        newNPC = Instantiate(infectNPC[randomCustOrNPC], spawnPoint.position, Quaternion.identity);

                    }
                    else
                    {

                        newNPC = Instantiate(customerNPC[randomCustOrNPC], spawnPoint.position, Quaternion.identity);
                    }
                    break;
                    

                case 7:
                    Debug.Log(numRecNPCs);
                    Debug.Log(maxRec);

                    if (numRecNPCs <= maxRec && recruitNPC.Count > 0)
                    {
                        int randomRecNPC = Random.Range(0, recruitNPC.Count);
                        GameObject recruitToSpawn = recruitNPC[randomRecNPC];

                        if (recruitToSpawn != null)
                        {
                            newNPC = Instantiate(recruitToSpawn, spawnPoint.position, Quaternion.identity);
                            Debug.Log("Recruited NPC Spawned");
                            recruitNPC.RemoveAt(randomRecNPC);
                        }
                    }
                    else
                    {
                        Debug.Log("Recruit NPC not spawned - max reached or list empty.");
                    }
                    break;
            }


            int randomOrder = Random.Range(0, 4);
           
            int randomCustomerText = 0;

            if (newNPC.tag == "Customer")
            {
               gameManager.KeyName = "enter";
                switch (randomOrder)
                {
                    case 0:
                        newNPC.AddComponent<MatchaOrder>();
                        break;

                    case 1:
                        newNPC.AddComponent<BrownSugarOrder>();
                        break;
                    case 2:
                        Debug.Log("Rad Order");
                        newNPC.AddComponent<RadOrder>();
                        break;
                    case 3:
                        newNPC.AddComponent<HoneyOrder>();
                        break;
                }


                switch (randomCustomerText)
                {
                    case 0:
                        GameObject newChild = Instantiate(customerTextPrefabs[0], newNPC.transform);
                        newChild.transform.localPosition = Vector3.zero;
                        newChild.transform.localRotation = Quaternion.identity;
                        newChild.transform.localScale = Vector3.one;
                        break;

                }
            }

            if (newNPC.tag == "Infected")
                
            {
                gameManager.KeyName = "enterinfect";
                if (randomCustOrNPC == 0 || randomCustOrNPC == 4 || randomCustOrNPC == 5)
                {
                    randomCustomerText = 0;
                }
                else if (randomCustOrNPC == 1 || randomCustOrNPC == 2 || randomCustOrNPC == 3 || randomCustOrNPC == 6)
                {
                    randomCustomerText = 1;
                }

                switch (randomCustomerText)
                {
                    case 0:
                        GameObject newChild = Instantiate(customerTextPrefabs[1], newNPC.transform);
                        newChild.transform.localPosition = Vector3.zero;
                        newChild.transform.localRotation = Quaternion.identity;
                        newChild.transform.localScale = Vector3.one;
                        break;

                    case 1:
                        GameObject newChild2 = Instantiate(customerTextPrefabs[2], newNPC.transform);
                        newChild2.transform.localPosition = Vector3.zero;
                        newChild2.transform.localRotation = Quaternion.identity;
                        newChild2.transform.localScale = Vector3.one;
                        break;


                }
            }
            if (newNPC.tag == "Recruit NPC1" || newNPC.tag == "Recruit NPC2" || newNPC.tag == "Recruit NPC3" || newNPC.tag == "Recruit NPC4")
            {
                gameManager.KeyName = "recruit";
                switch (randomCustomerText)
                {
                    case 0:
                        GameObject newChild = Instantiate(recruitTextPrefabs[0], newNPC.transform);
                        newChild.transform.localPosition = Vector3.zero;
                        newChild.transform.localRotation = Quaternion.identity;
                        newChild.transform.localScale = Vector3.one;
                        break;
                }
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


