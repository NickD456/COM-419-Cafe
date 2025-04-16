using UnityEngine;

public class DestroyTalk : MonoBehaviour
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
        if (gameManager.destroyTalk)
            DestroyLootObject();
    }

    public void DestroyLootObject()
    {
        if (gameManager.destroyTalk)
        {
            Debug.Log("gfddfgdf");
           
            Destroy(this.gameObject);
            gameManager.isTalking = false;
            gameManager.destroyTalk = false;
        }
    }

   
}
