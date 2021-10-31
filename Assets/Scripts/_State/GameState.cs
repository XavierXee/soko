using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : Singleton<GameState>
{

    private int[] currentCharacterPosition = new int[2];
    private int[] nextCharacterPosition = new int[2];

    void Awake()
    {

    }

    public void setState(float x, float y)
    {
        currentCharacterPosition[0] = (int)x;
        currentCharacterPosition[1] = (int)y;
        Debug.Log(" :: State Update :::: " + getState());
    
    }

    public string getState()
    {
        return currentCharacterPosition[0].ToString() + " " + currentCharacterPosition[1].ToString();
    }

}
