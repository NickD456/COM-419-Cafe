using UnityEngine;
using UnityEngine.AI;

public class NavScript : MonoBehaviour
{
  
    private NavMeshAgent agent;
    private GameObject des;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        des = GameObject.FindWithTag("Line Spot");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = des.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Customer") && other.gameObject.GetInstanceID() != gameObject.GetInstanceID())
        {
            if (other.transform.position.z > transform.position.z)
            {
                agent.isStopped = true;
            }
        }
    }
}
