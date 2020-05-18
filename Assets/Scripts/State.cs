using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject {

    [TextArea(10,14)] [SerializeField] string   StoryText;
    [TextArea(5, 14)] [SerializeField] string   ChoicesText;
    [TextArea(1, 14)] [SerializeField] string[] SceneItems;

    [SerializeField] State[] nextStates;

    public string GetStoryText() {
	return StoryText;
    }

    public string GetChoicesText() {
	return ChoicesText;
    }

    public State[] GetNextStates() {
	return nextStates;
    }

    public string[] GetItems() {
	return SceneItems;
    }

}
