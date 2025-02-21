using UnityEngine;
using UnityEngine.SceneManagement;

public class NightEnd : MonoBehaviour
{


public string nextSceneName;
private NightEnd nightend;
public int zombieCount = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(zombieCount == 0){
           //SceneManager.LoadScene(SampleScene);
        }
    }

}