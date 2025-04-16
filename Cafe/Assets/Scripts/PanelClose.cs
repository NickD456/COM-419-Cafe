using UnityEngine;

public class PanelClose : MonoBehaviour
{
    public GameObject panel;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.firstDay)
        {
            panel.SetActive(true);
        }

        else
        {
            panel.SetActive(false);
        }
    }

    public void ClosePanel()
    {
        gameManager.firstDay = false;
        panel.SetActive(false);
    }
}
