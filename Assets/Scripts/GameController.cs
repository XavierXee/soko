using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : Singleton<GameController>
{
    
    public Transform PointerPrefab;
    [HideInInspector] public Transform Pointer;

    public GameObject[] CharactersArray;

    private int CurrentControlledCharacterIndex = 0;

    private void Awake() {
        if (Pointer == null) {
            Pointer = Instantiate(PointerPrefab, transform.position, transform.rotation);
        }
    }

    private void Start() {
        CharactersArray[CurrentControlledCharacterIndex].GetComponent<CharaController>().StartControl();
    }

    public void MoveControlledCharacter(InputAction.CallbackContext Context) {
        CharactersArray[CurrentControlledCharacterIndex].GetComponent<CharaController>().SetInputValue(Context.ReadValue<Vector2>().x, Context.ReadValue<Vector2>().y);
    }

    public void SwitchControlledCharacter(InputAction.CallbackContext Context) {
        if (Context.performed) {
            CharactersArray[CurrentControlledCharacterIndex].GetComponent<CharaController>().StopControl();
            CurrentControlledCharacterIndex = CurrentControlledCharacterIndex == CharactersArray.Length - 1 ? 0 : CurrentControlledCharacterIndex + 1;
            CharactersArray[CurrentControlledCharacterIndex].GetComponent<CharaController>().StartControl();
        }
    }

}
