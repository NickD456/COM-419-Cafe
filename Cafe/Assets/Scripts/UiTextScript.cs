using UnityEngine;

public class UiTextScript : MonoBehaviour
{
    private GameManager gameManager;

    public TMPro.TMP_Text dayNum;
    public TMPro.TMP_Text money; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        dayNum.text = "Day: " + gameManager.dayNum;
        money.text = "Money: $" + gameManager.money;
    }
}
