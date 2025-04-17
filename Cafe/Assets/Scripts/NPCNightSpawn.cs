using UnityEngine;

public class NPCNightSpawn : MonoBehaviour
{

private NightEnd nightend;
private GameManager gameManager;

public Transform spawnPoint1; 
public Transform spawnPoint2;
public Transform spawnPoint3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
              gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

       
        if (gameManager.recruitedNPC[1] != null){
           Instantiate(gameManager.recruitedNPC[1], spawnPoint1.position, Quaternion.identity);
        if (gameManager.recruitedNPC[2] != null){
           Instantiate(gameManager.recruitedNPC[2], spawnPoint2.position, Quaternion.identity);
        if (gameManager.recruitedNPC[3] != null){
           Instantiate(gameManager.recruitedNPC[3], spawnPoint3.position, Quaternion.identity);

        }
    }
    }

}
}