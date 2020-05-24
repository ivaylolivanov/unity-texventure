using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject {

    [TextArea(10, 14)] [SerializeField] private string StoryText;
    [TextArea(5, 14)] [SerializeField]  private string ChoicesText;
    [TextArea(1, 14)] [SerializeField]  private string[] SceneItems;

    [SerializeField] private  string[] ChoicesCost;
    [SerializeField] private List<State> nextStates;

    private List<State> usedStates = new List<State>();

    public string GetStoryText() {
        return StoryText;
    }

    public string GetChoicesText() {
        return ChoicesText;
    }

    public List<State> GetNextStates() {
        return nextStates;
    }

    public string[] GetItems() {
        return SceneItems;
    }

    public string[] GetChoicesCost() {
        return ChoicesCost;
    }

    public void Use(State s) {
        this.usedStates.Add(s);
    }

    public bool IsUsed(State s) {
	if(usedStates.Contains(s)) return true;
	else return false;
    }
}
