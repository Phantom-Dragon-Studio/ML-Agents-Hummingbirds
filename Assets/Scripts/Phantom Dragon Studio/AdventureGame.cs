using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI storyText;
    [SerializeField] public State[] allStates;
    public State state;
    private int currentIndex;
    private int numberOfStates;

    void Start()
    {
        numberOfStates = allStates.Length;
        state = allStates[0];
        storyText.text = state.GetStateStory();
    }

    public void ManageState(int index)
    {
        Debug.Log(allStates[index]);
        if (numberOfStates <= index)
        {
            currentIndex = index;
            state = allStates[index];
            storyText.text = state.GetStateStory();
        }
    }

    public void CurrentOptions()
    {
        allStates[currentIndex].GetNextStates();
    }
}

internal class TextMeshProUGUI
{

    public string text;
}