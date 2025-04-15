using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    private GameManager gameManager;
    private string oldString;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Entered Trigger");
            oldString = gameManager.KeyName;
            gameManager.KeyName = "send_out";
            Debug.Log("Key Name: " + gameManager.KeyName);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exit Trigger");
            gameManager.KeyName = oldString;
            Debug.Log("Key Name: " + gameManager.KeyName);
        }
    }
}
