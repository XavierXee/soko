using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject chara_0;
    public GameObject chara_1;
    public GameObject chara_2;
    GameObject[] characterArray;

    CharaController characterController;
    int currentControlledCharacterIndex = 0;

	void ChangeControlledCharacter() {
        if (Input.GetKeyDown("space")) {
        	characterArray[currentControlledCharacterIndex].GetComponent<CharaController>().StopControl();
			currentControlledCharacterIndex = currentControlledCharacterIndex == characterArray.Length - 1 ? 0 : currentControlledCharacterIndex + 1;
			characterArray[currentControlledCharacterIndex].GetComponent<CharaController>().StartControl();
        }
    }

    void MakeCharacterFollow() {
        if (Input.GetKeyDown("f")) {
        	Transform followPoint = characterArray[currentControlledCharacterIndex].GetComponent<CharaController>().GetFollowPoint();
        	characterArray[1].GetComponent<CharaController>().SetExternalFollowPoint(followPoint);
        	characterArray[1].GetComponent<CharaController>().StartFollow();
        }
    }

    void Start() {
    	characterArray = new GameObject[] {chara_0, chara_1, chara_2};
    	characterArray[currentControlledCharacterIndex].GetComponent<CharaController>().StartControl();
    }

    void Update() {
    	ChangeControlledCharacter();
    	MakeCharacterFollow();
    }
}
