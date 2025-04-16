using UnityEngine;

public class RecruitScript : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject recruitNPC1;
    public GameObject recruitNPC2;
    public GameObject recruitNPC3;
    public GameObject recruitNPC4;
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
        GameObject root = other.transform.root.gameObject;

        if (root.CompareTag("Recruit NPC1") && !gameManager.recruitedNPC.Contains(recruitNPC1))
        {

            Debug.Log("Recruit NPC1");
            gameManager.recruitedNPC.Add(recruitNPC1);

            Destroy(root);
        }




       
    }
}
