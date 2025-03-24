using HarmonyDialogueSystem;
using UnityEngine;
using static UnityEditor.Progress;

public class KeyCheck : MonoBehaviour
{
    private Character character;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddSubscriber();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddSubscriber()
    {
        CharacterManager.instance.characterChanged.AddListener(GetCharacterTag);
    }

    public void GetCharacterTag(Character character)
    {
        string tag = "enter";

    if (character.LookForCharacterTag(tag, out string value))
        {
            Debug.Log(value);
            if(value == "yes")
            {
                Debug.Log("Now here");
            }
            else if (value == "no")
            {
                Debug.Log("Not here");
            }

        }
    }
}
