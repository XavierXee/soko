using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaManager : MonoBehaviour
{
    
    // private Move ActionMove;
    // private Interact ActionInteract;

    public Transform Pointer;
    public Transform PointerPrefabBlue;

    private Dictionary<string, Behaviour> Actions = new Dictionary<string, Behaviour>();

    // private void OnEnable() {
    //     if (Pointer == null) {
    //         Pointer = Instantiate(PointerPrefabBlue, transform.position, transform.rotation);
    //     } else {
    //         Pointer.position = transform.position;
    //     }
    // }

    private void InstanciatePointer () {
        if (Pointer == null) {
            Pointer = Instantiate(PointerPrefabBlue, transform.position, transform.rotation);
        } else {
            Pointer.position = transform.position;
        }
    }

    private void Awake() {
        InstanciatePointer();
        SetActionsList();
    }

    private void SetActionsList() {
        Actions.Add("Move", GetComponent<Move>());
        Actions.Add("Interact", GetComponent<Interact>());
        Actions.Add("Replicate", GetComponent<Replicate>());
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
