using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

// duplicated variables but with a formal wrapper class
// so they refer to the same underlying store

public class DuplicateVariables : MonoBehaviour {
    private CustomVariableStorage variableStorage;

    public void Start() {
        variableStore = GameObject.FindObjectOfType<CustomVariableStorage>();
    }

    public void AddPlayerCurrency(float amount) {
        // You are doing the TryGetValue but we aren't responsible for doing that every time
        // can treat the variableStore as if it's holding locally managed variables
        variableStore.PlayerCoins += amount;
    }
}
