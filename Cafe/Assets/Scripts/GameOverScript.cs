using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    private GameManager gameManager;
    public TMPro.TMP_Text Days;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Days.text = "Days Survived: " + gameManager.dayNum;
        
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(2);
        Destroy(gameManager.gameObject);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
