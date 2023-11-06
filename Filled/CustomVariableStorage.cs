using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CustomVariableStorage : InMemoryVariableStorage {
    // asks the underlying variable storage what its current value is
    // and when you set it b ack, it sets it back
    
    public float PlayerCoins {
        get { return this.GetFloat("$player_coins"); }
        set { this.SetValue("$player_coins", value); }
    }
}