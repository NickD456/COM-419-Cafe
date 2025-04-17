using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{
    private PlayableDirector director; 
    public GameObject controlPanel;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        director = GetComponent<PlayableDirector>();
        director.played += Director_Played; 
        director.stopped += Director_Stopped;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManager.letInfectIn)
        {
            PlayTimeline();
        }
    }

    private void Director_Played(PlayableDirector obj)
    {
        controlPanel.SetActive(false);
    }

    private void Director_Stopped(PlayableDirector obj)
    {
        controlPanel.SetActive(true);
    }

    public void PlayTimeline()
    {
        if (director != null)
        {
            Debug.Log("Playing Timeline");
            director.Play();
        }
    }

    // Update is called once per frame
   
}
