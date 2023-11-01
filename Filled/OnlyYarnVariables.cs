using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

// use Yarn variables only
// don't keep any long-lived copies on the C# side

public class OnlyYarnVariables : MonoBehaviour {
    private InMemoryVariableStorage variableStorage;

    public void Start() {
        // A handle to the current variable storage
        variableStorage = FindObjectOfType<InMemoryVariableStorage>;
    }
    public void AddPlayerCurrency(float amount) {
        // Use a temporary variable for our TryGetValue function
        // This is then populated by the TryGetValue function
        float temp;
        // try to get Yarn variable, else set default settings
        if (!variableStorage.TryGetValue("$player_coins", out temp)) {
            temp = 0;
        }
        // setYarn variable to updated value
        // temp variable discarded from C# script
        // goes away when the function ends - meaning no persistent value whatsoever
        variableStorage.SetValue("$player_coins", temp + amount);
        // This variable storage is storing this value anyway in a dictionary
        // or some sort of ariable storage data structure in C#'s memory
    }
}

