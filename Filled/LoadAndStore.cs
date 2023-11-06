using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

// load Yarn variable initial values from C# on startup
// store values back to C# on shutdown

public class LoadAndStore : MonoBehaviour {
    private DialogueRunner runner;
    private InMemoryVariableStorage variableStore;

    // local dictionaries that hold the variable name and value. 
    private Dictionary<string, float> floatVariables = new Dictionary<string, float> {
        {"$player_coins", 0}
    };
    private Dictionary<string, string> stringVariables = new Dictionary<string, string> {};
    private Dictionary<string, bool> boolVariables = new Dictionary<string, bool> {};
    public void Start() {
        // get a handle to the Scene's DialogueRunner and its VariableStorage
        runner = GameObject.FindObjectOfType<DialogueRunner>();
        variableStore = GameObject.FindObjectOfType<DialogueRunner>();
        // need commands to load and store variables
        // when we ask it to get variables, it will help us set those values from the C# side
        // these values are then used in functions
        runner.AddCommandHandler("load_variables", LoadVariables);
        runner.AddCommandHandler("store_variables", StoreVariables);

    }

    private void LoadVariables() {
        // initialize C# dictionaries from wherever you saved
        // values outside of running memory, such as a file
        // we are reading all values that are saved on disk
        variableStore.SetAllVariables(
            floatVariables,
            stringVariables,
            boolVariables
        );
        Debug.Log("Variables loaded.");
    }

    private void StoreVariables() {
        // GetAllVariables is a function of InMemoryVariableStorage
        // sets all the variables in the memory to all the correct values
        // store values somewhere for long-term, such as by
        // serializing them out to a JSON file
        // GetAllVariables gets back all three dictionaries 
        var varDicts = variableStore.GetAllVariables();
        floatVariables = varDicts.Item1;
        stringVariables = varDicts.Item2;
        boolVariables = varDicts.Item3;

        Debug.Log("Variables stored.");
    }
}

