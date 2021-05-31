using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaController : MonoBehaviour
{
    
    private Move ActionMove;
    private Interact ActionInteract;

    private Dictionary<string, Behaviour> Actions = new Dictionary<string, Behaviour>();

    private void Awake() {
        Actions.Add("Move", GetComponent<Move>());
        Actions.Add("Interact", GetComponent<Interact>());
    }

    public void EnableAction(string ActionName) {
        Actions[ActionName].enabled = true;
    }

    public void DisableAction(string ActionName) {
        Actions[ActionName].enabled = false;
    }

    public void EnableAllActions() {
        foreach (KeyValuePair<string, Behaviour> Action in Actions) {
             Action.Value.enabled = true;
        }
    }

    public void DisableAllActions() {
        foreach (KeyValuePair<string, Behaviour> Action in Actions) {
             Action.Value.enabled = false;
        }
    }

}
