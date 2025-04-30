using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    //public GameObject Target;
    public float speed = 1.5f;
    public Transform Player;
    public float updatePath = .1f;
    public GameObject gun;
    private GameManager gameManager;
    private GameObject PlayerGame;
    GameObject closest = null;

    //public Transform player;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Awake()
    {

    }
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerGame = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        // Player = gun;
        // GetComponent<NavMeshAgent>();

       

    }

    // Update is called once per frame
    void Update()
    {
        FindClosestTarger();
        StartCoroutine(FollowTarget());
        transform.LookAt(closest.transform);
       // transform.Translate(Vector3.forward *Time.deltaTime * speed);


       //transform.LookAt(Target.transform);
       //transform.Translate(Vector3.forward *Time.deltaTime * speed);

    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds wait = new WaitForSeconds(updatePath);

        while (enabled)
        {
            agent.SetDestination(closest.transform.position);

            yield return wait;
        }
    }

    GameObject FindClosestTarger()
    {
        float playerDistance = Vector3.Distance(transform.position, Player.position);
        closest = null;
        if (gameManager.spawn1 || gameManager.spawn2 || gameManager.spawn4 || gameManager.spawn3)
        {

            GameObject[] targets = GameObject.FindGameObjectsWithTag("npcspawn");

            float minDist = Mathf.Infinity;


            foreach (GameObject zombie in targets)
            {
                float dist = Vector3.Distance(transform.position, zombie.transform.position);
                if (dist < minDist && dist <= playerDistance)
                {
                    minDist = dist;
                    closest = zombie;
                }
                else
                {
                    closest = PlayerGame;
                }

            }


        }
        else
        {
            closest = PlayerGame;
        }
        
        return closest;
    }
}
