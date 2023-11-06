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
        runner = GameObject.FindObjectOfType<DialogueRunner>();
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
        float temp;
        if (!variableStorage.TryGetValue("$player_coins", out temp)) {
            temp = 0;
        }
        variableStorage.SetValue("$player_coins", temp + amount);
    }
}

