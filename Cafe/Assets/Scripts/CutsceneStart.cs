using UnityEngine;

public class CutsceneStart : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject cutscene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.letInfectIn)
        {
            cutscene.SetActive(true);
        }
    }
}
