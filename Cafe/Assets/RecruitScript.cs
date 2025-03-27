using UnityEngine;

public class RecruitScript : MonoBehaviour
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
        if (other.gameObject.tag == "Recruit NPC")
        {
            gameManager.isTalking = false;
            gameManager.canEnter = false;
            gameManager.canTalk = true;
            gameManager.turnBack = false;
            gameManager.isRecruit = false;

            gameManager.npcArray[0] = other.gameObject;

            Destroy(other.gameObject);

            



        }
    }
}
