using HarmonyDialogueSystem;
using UnityEngine;
using static UnityEditor.Progress;

public class KeyCheck : MonoBehaviour
{
    private Character character;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Object")
        {
            character.LookForCharacterTag("enter" out "Yes");
        }
    }
}
