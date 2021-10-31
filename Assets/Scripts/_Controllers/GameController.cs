using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : Singleton<GameController>
{

    public GameObject[] CharactersArray;

    private int CurrentControlledCharacterIndex = 0;

    private void Awake() {
    }

    private void Start() {
        // CharactersArray[CurrentControlledCharacterIndex].GetComponent<CharaController>().EnableAction("Move");
        // CharactersArray[CurrentControlledCharacterIndex].GetComponent<CharaController>().EnableAction("Interact");

        // CharactersArray[1].GetComponent<CharaController>().EnableAction("Replicate");
    }

    public void onDirectionInput(InputAction.CallbackContext Context) {
        InputHandler.Instance.SetValues(Context.ReadValue<Vector2>().x, Context.ReadValue<Vector2>().y);
    }

    public void SwitchControlledCharacter(InputAction.CallbackContext Context) {
        if (Context.performed) {
            // CharactersArray[CurrentControlledCharacterIndex].GetComponent<CharaController>().DisableAllActions();
            // CurrentControlledCharacterIndex = CurrentControlledCharacterIndex == CharactersArray.Length - 1 ? 0 : CurrentControlledCharacterIndex + 1;
            // CharactersArray[CurrentControlledCharacterIndex].GetComponent<CharaController>().EnableAllActions();
        }
    }

}
