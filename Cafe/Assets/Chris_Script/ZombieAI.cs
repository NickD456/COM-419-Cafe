using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    //public GameObject Target;
    public float speed = 1.5f;

    //public Transform player;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        transform.Translate(Vector3.forward *Time.deltaTime * speed);


       //transform.LookAt(Target.transform);
       //transform.Translate(Vector3.forward *Time.deltaTime * speed);

    }
}
