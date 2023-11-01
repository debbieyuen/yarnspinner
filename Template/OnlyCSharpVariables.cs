using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

// use C# variables only
// don't keep any long-lived copies on the Yarn side

public class OnlyCSharpVariables : MonoBehaviour {
    private DialogueRunner runner;
    private static float playerCoins;
    private static const float maxPlayerCoins = 50;
    public void Start() {
        // get a handle to the Scene's DialogueRunner
        // get dialogue runner instead of the variable storage
        runner = GameObject.FindObjectOfType<DialogueRunner>();
        // add functions that allow getting and changing of this value
        runner.AddFunction<float>("get_player_coins", GetPlayerCoins);
        runner.AddFunction<bool, float>("set_player_coins", SetPlayerCoins);
        runner.AddFunction<bool, float>("add_player_coins", AddPlayerCoins);
        runner.AddFunction<bool, float>("subtract_player_coins", SubtractPlayerCoins);
    }

    // Function to get the current number of player coins
    private static float GetPlayerCoins() {
        return playerCoins;
    }

    // Function to set a specific number
    private static bool SetPlayerCoins(float newValue) {
        if (newValue >= 0 && newValue <= maxPlayerCoins) {
            playerCoins = newValue;
            return true;
        }
        return false;
    }

    private static bool AddPlayerCoins(float addValue) {
        float newValue = playerCoins + addValue;
        return SetPlayerCoins(newValue);
    }

    private static bool SubtractPlayerCoins(float addValue) {
        float newValue = playerCoins - addValue;
        return SetPlayerCoins(newValue);
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

