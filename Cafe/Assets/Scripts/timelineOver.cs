using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class timelineOver : MonoBehaviour
{
    public PlayableDirector timelineDirector;
    

    void Start()
    {
        if (timelineDirector != null)
        {
            timelineDirector.stopped += OnTimelineFinished;
        }
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        // You can quit or load another scene here
        Debug.Log("Timeline finished!");

        SceneManager.LoadScene(1); 
    }

    void OnDestroy()
    {
        if (timelineDirector != null)
        {
            timelineDirector.stopped -= OnTimelineFinished;
        }
    }
}
