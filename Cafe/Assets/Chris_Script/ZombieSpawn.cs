using UnityEngine;
using System.Collections;


public class ZombieSpawn : MonoBehaviour
{
    public GameObject ZombiePrefab;
    public Transform zombieSpawn;
    private GameManager gameManager;
    private NightEnd nightend;

    void Start()
    {
        Instantiate(ZombiePrefab, zombieSpawn.position, Quaternion.identity);
        nightend.zombieCount += 1;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    
        for(int i = 0; i< gameManager.dayNum; i++){

        Instantiate(ZombiePrefab, zombieSpawn.position, Quaternion.identity);
        }
     
    }

    IEnumerator delay(){
        yield return new WaitForSeconds(2);
    }

}
