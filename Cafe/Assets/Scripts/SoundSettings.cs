using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public GameObject nonSet;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1f); // Set default volume if none exists
        }

        else
        {
            Load();
        }

        AudioListener.volume = volumeSlider.value;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume"); // Default volume is 1 (max)
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
       
    }

    public void ShowVolSet()
    {
        volumeSlider.gameObject.SetActive(true);
        nonSet.SetActive(false);
    }
    public void HideVolSet()
    {
        volumeSlider.gameObject.SetActive(false);
        nonSet.SetActive(true);
    }
}
