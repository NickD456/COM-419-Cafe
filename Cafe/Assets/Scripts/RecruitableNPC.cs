using UnityEngine;

public class RecruitableNPC : MonoBehaviour
{
    private GameManager gameManager;
    private int npcNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Awake()
    {

        npcNumber = UnityEngine.Random.Range(0, 9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Recruited()
    {
        gameManager.AddNPC(npcNumber);
    }
}
