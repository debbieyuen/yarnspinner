using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CustomVariableStorage : InMemoryVariableStorage {
    
    public float PlayerCoins {
        get { return this.GetFloat("$player_coins"); }
        set { this.SetValue("$player_coins", value); }
    }
}