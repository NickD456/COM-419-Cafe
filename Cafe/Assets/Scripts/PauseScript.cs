using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseScreen;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
                
            }
            else
            {
                Pause();

            }
        }
    }

    public void Pause()
    {
        if (!isPaused)
        {
            gameManager.isPaused = true;
            Time.timeScale = 0f;
            Debug.Log("aused");
            isPaused = true;
            pauseScreen.SetActive(true);
            

        }
    }

    public void Resume()
    {
        if (isPaused)
        {
            gameManager.isPaused = false;
            Time.timeScale = 1f;
            isPaused = false;   
            pauseScreen.SetActive(false);
            
        }
    }

    public void quit()
    {
        Application.Quit(); 
    }

    public void MainMenu()
    {
        if (isPaused)
        {
            gameManager.isPaused = false;
            Time.timeScale = 1f;
            isPaused = false;
            pauseScreen.SetActive(false);

        }
        SceneManager.LoadScene(0);
    }
}
