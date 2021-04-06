using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : Singleton<Global>
{

    [HideInInspector] public float MoveSpeed = 5f;

    [HideInInspector] public string LayerMaskWallName = "Wall";
    [HideInInspector] public string LayerMaskCharacterName = "Character";

    [HideInInspector] public LayerMask LayerMaskWall;
    [HideInInspector] public LayerMask LayerMaskCharacter;

	private void Awake() {
		LayerMaskWall = LayerMask.GetMask(LayerMaskWallName);
    	LayerMaskCharacter = LayerMask.GetMask(LayerMaskCharacterName);
	}

}