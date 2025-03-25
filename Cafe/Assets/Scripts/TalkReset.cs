using UnityEngine;

public class TalkReset : MonoBehaviour
{

    private GameManager gameManager;
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
        if (other.gameObject.tag == "Customer")
        {
            gameManager.canEnter = false;
           Debug.Log("Can Enter: " + gameManager.canEnter);
        }
    }
}
