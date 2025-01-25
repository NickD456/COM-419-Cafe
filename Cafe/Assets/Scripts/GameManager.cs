using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Number of NPCs. Will change when NPC is recruited or dies.
    private int npcCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Add NPC when recruited. NPC type and name will be handled through tags. 
    public void AddNPC()
    {
        npcCount++;
    }

    //Sub NPC when dies or dismissed. NPC type and name will be handled through tags.
    public void SubNPC()
    {
        npcCount--;
    }
}
