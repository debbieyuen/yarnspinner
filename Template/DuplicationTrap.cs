using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DuplicationTrap : MonoBehaviour {

    private InMemoryVariableStorage variableStorage;

    // Create a new variable within C# 
    private float playerCoins;
    private void Start() {
        variableStorage = FindObjectOfType<InMemoryVariableStorage>();
    }

    private void AddPlayerCurrency(float amount) {
        // Get variable
        variableStorage.TryGetValue("$player_coins", out playerCoins);
        // Set variable
        variableStorage.SetValue("$player_coins", playerCoins);
        playerCoins += amount;
    }
}