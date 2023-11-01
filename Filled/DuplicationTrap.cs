using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DuplicationTrap : MonoBehaviour {
    // Handle to the variable storage from the running DialogueRunner from Yarn Spinner
    // How we access the values that Yarn Spinner is currently storing
    private InMemoryVariableStorage variableStorage;
    // Current number of coins a player has
    private float playerCoins;

    public void Start() {
        // A handle to the current variable storage
        variableStorage = FindObjectOfType<InMemoryVariableStorage>;
    }

    public void AddPlayerCurrency(float amount) {
        // Trying to get the variable from Yarn Spinner
        // Right now the C# side of the equation, playerCoins thinks that
        // the player coins amount was the initial amount from the Yarn Spinner side
        variableStorage.TryGetValue("$player_coins", out playerCoins);
        // Store the change back. So we now have to "get" the initial value from yarn spinner
        // we need to increment to change the amount and 
        // then we have to set back to tell Yarn
        // that the vaue has changed. 
        variableStorage.SetValue("$player_coins", playerCoins);
        playercoints += amount;
    }
}