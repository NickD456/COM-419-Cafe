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
        if (other.gameObject.tag == "Customer" || other.gameObject.tag == "Recruit NPC")
        {
            gameManager.isTalking = false;
            gameManager.canEnter = false;
            gameManager.canTalk = true;
            gameManager.turnBack = false;
            Debug.Log("Can Enter: " + gameManager.canEnter);

            if(other.gameObject.tag == "Recruit NPC")
            {
                Destroy(other.gameObject);
            }


           
        }
    }
}
