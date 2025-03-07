using UnityEngine;

public class MusicSelect : MonoBehaviour
{
    public AudioSource myAudioSource;
    public AudioClip[] myClips;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!myAudioSource.isPlaying)
        {
            AudioClip randomClip = myClips[Random.Range(0,myClips.Length)];

            myAudioSource.PlayOneShot(randomClip);
        }
    }
}
