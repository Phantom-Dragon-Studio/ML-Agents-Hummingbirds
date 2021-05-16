using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "State")]

public class State : ScriptableObject
{

    [TextArea(10, 14)] [SerializeField] string storyText;
    [FormerlySerializedAs("nextStates")] [SerializeField] State[] options;
    public int StateID;

    public int GetIndex()
    {
        var indexToReturn = -1;
        var gm = FindObjectOfType<AdventureGame>();
        for (int i = 0; i < gm.allStates.Length; i++)
        {
            if (gm.allStates[i] == this)
            {
                indexToReturn = i;
            }
        }

        return indexToReturn;
    }

    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return options;
    }
}