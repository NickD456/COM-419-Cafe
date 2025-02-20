using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public GameObject Zombie;
    public Transform zombieSpawn;

    // Start islled once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i< dayNum; i++){
        Instantiate(zombiePrefab, zombieSpawn.position, Quaternion.identity);
        }
    }

}
