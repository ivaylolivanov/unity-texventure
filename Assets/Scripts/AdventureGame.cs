using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text  storyTextComponent;
    [SerializeField] Text  inventoryTextComponent;
    [SerializeField] Text  choicesTextComponent;
    [SerializeField] State startingState;

    State state;
    State prevState;

    Dictionary<string, int> inventoryItems = new Dictionary<string, int>();

    void Start() {
	state = startingState;

	storyTextComponent.text     = state.GetStoryText();
	choicesTextComponent.text   = state.GetChoicesText();

	inventoryItems.Add("Gold",   0);
	inventoryItems.Add("Silver", 0);
    }

    // Update is called once per frame
    void Update() {
	ManageState();
    }

    private void ManageState() {
	var nextStates = state.GetNextStates();
	string[] sceneItems;

	prevState = state;

	if(Input.GetKeyDown(KeyCode.Alpha1)) {
	    state = nextStates[0];
	}
	else if(Input.GetKeyDown(KeyCode.Alpha2)) {
	    state = nextStates[1];
	}
	else if(Input.GetKeyDown(KeyCode.Alpha3)) {
	    state = nextStates[2];
	}
	else if(Input.GetKeyDown(KeyCode.Alpha4)) {
	    state = nextStates[3];
	}

	storyTextComponent.text   = state.GetStoryText();
	choicesTextComponent.text = state.GetChoicesText();

	if(prevState != state){
	    UpdateInventory(state);
	    ShowInventory();
	}
    }

    private void UpdateInventory(State currentState) {
	string[] SceneItems = currentState.GetItems();

	if(SceneItems != null) {
	    foreach(var item in SceneItems) {
		if(inventoryItems.ContainsKey(item)) {
		    inventoryItems[item] += 1;
		}

		else {
		    inventoryItems.Add(item, 1);
		}
	    }
	}
    }

    private void ShowInventory() {
	inventoryTextComponent.text = "";

	foreach(KeyValuePair<string, int> item in inventoryItems) {
	    inventoryTextComponent.text += item.Value + " x " + item.Key + "\n";
	}

	// inventoryTextComponent.text += "\n";
    }
}
