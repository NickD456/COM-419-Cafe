using UnityEngine;
using System.Collections;


public class ZombieSpawn : MonoBehaviour
{
    public GameObject ZombiePrefab;
    public Transform zombieSpawn;
    private GameManager gameManager;
    private NightEnd nightend;
    int i = 0;
    void Start()
    {
        Instantiate(ZombiePrefab, zombieSpawn.position, Quaternion.identity);
        nightend.zombieCount += 1;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    
        i= 0;

        while(i < 5)
        {

        Instantiate(ZombiePrefab, zombieSpawn.position, Quaternion.identity);
        nightend.zombieCount += 1;
        i++;
        }
     
    }

    void Update()
    {
        
    }

    IEnumerator delay(){
        yield return new WaitForSeconds(2);
    }

}

