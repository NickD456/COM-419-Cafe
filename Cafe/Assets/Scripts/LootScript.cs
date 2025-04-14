using UnityEngine;

public class LootScript : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager.recruitedNPC.Count != 0)
        {
            SendLooting();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SendLooting()
    {
        
    }
}
