using UnityEngine;

public class DestroyCust : MonoBehaviour
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
        if (gameManager.destroyCust)
            DestroyTalkObject();
    }

    public void DestroyTalkObject()
    {
        if (gameManager.destroyCust)
        {
            
            Destroy(this.gameObject);
            gameManager.isTalking = false;
            gameManager.destroyCust = false;
        }
    }
}
