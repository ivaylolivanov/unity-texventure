using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    string[] expendableItems = {
	"Gold coin",
	"Silver coin",
	"Bread",
	"Red potion",
	"Silver potion",
	"Unidentified Herb"
    };

    void Start() {
	state = startingState;

	storyTextComponent.text   = state.GetStoryText();
	choicesTextComponent.text = state.GetChoicesText();
    }

    void Update() {
	if (Input.GetKey("escape")) {
            Application.Quit();
        }
	ManageState();
    }

    private void ManageState() {
	List<State> nextStates = state.GetNextStates();
	string[] sceneItems = state.GetItems();
        string[] choiceCost = state.GetChoicesCost();

        if (prevState != state) { TakeItems(sceneItems); }

        prevState = state;

	if (Input.GetKeyDown(KeyCode.Alpha1)) {
            int stateIndex = 0;
            string cost = stateIndex < choiceCost.Length ? choiceCost[stateIndex] : "";
	    if(IsChoiceAffordable(cost) && stateIndex < nextStates.Count && !state.IsUsed(nextStates[stateIndex])) {
		state = nextStates[stateIndex];
		UpdateInventory(cost);
                prevState.Use(state);
            }
	}
	else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            int stateIndex = 1;
            string cost = stateIndex < choiceCost.Length ? choiceCost[stateIndex] : "";
	    if(IsChoiceAffordable(cost) && stateIndex < nextStates.Count && !state.IsUsed(nextStates[stateIndex])) {
		state = nextStates[stateIndex];
		UpdateInventory(cost);
                prevState.Use(state);
            }
	}
	else if (Input.GetKeyDown(KeyCode.Alpha3)) {
	    int stateIndex = 2;
            string cost = stateIndex < choiceCost.Length ? choiceCost[stateIndex] : "";
	    if(IsChoiceAffordable(cost) && stateIndex < nextStates.Count && !state.IsUsed(nextStates[stateIndex])) {
		state = nextStates[stateIndex];
		UpdateInventory(cost);
		prevState.Use(state);
            }
	}
	else if (Input.GetKeyDown(KeyCode.Alpha4)) {
	    int stateIndex = 3;
            string cost = stateIndex < choiceCost.Length ? choiceCost[stateIndex] : "";
	    if(IsChoiceAffordable(cost) && stateIndex < nextStates.Count && !state.IsUsed(nextStates[stateIndex])) {
		state = nextStates[stateIndex];
		UpdateInventory(cost);
		prevState.Use(state);
            }
	}

        storyTextComponent.text   = state.GetStoryText();
	choicesTextComponent.text = state.GetChoicesText();
	ShowInventory();
    }

    private bool IsChoiceAffordable(string cost) {
        if(cost == "") return true;
        if(! inventoryItems.ContainsKey(cost)) {
            return false;
	}

	return true;
    }

    private void UpdateInventory(string cost) {
	if (inventoryItems.ContainsKey(cost)) {
	    if (expendableItems.Contains(cost)) {
		--inventoryItems[cost];
	    }

	    if(inventoryItems[cost] <= 0) {
		inventoryItems.Remove(cost);
	    }
	}
    }

    private void TakeItems(string[] items) {
        foreach(var item in items) {
	    if(inventoryItems.ContainsKey(item)) {
		inventoryItems[item] += 1;
	    }

	    else {
		inventoryItems.Add(item, 1);
	    }
	}
    }

    private void ShowInventory() {
        inventoryTextComponent.text = "";

        foreach(KeyValuePair<string, int> item in inventoryItems) {
	    inventoryTextComponent.text += item.Value + " x " + item.Key + ", ";
	}

	// inventoryTextComponent.text += "\n";
    }
}
