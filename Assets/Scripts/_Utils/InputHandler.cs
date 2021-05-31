using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : Singleton<InputHandler>
{

	private float InputX;
    private float InputY;

	private bool isLastInputHorizontal;

    public void SetValues(float InputXValue, float InputYValue) {
        InputX = InputXValue;
        InputY = InputYValue;
    }

    public Vector3 GetVector() {
    	if (!(Mathf.Abs(InputX) == 0 && Mathf.Abs(InputY) == 0)) {
            if (Mathf.Abs(InputX) > Mathf.Abs(InputY)) {
                isLastInputHorizontal = true;
                return new Vector3(Mathf.Round(InputX), 0f, 0f);
            } else if (Mathf.Abs(InputX) < Mathf.Abs(InputY)) {
                isLastInputHorizontal = false;
                return new Vector3(0f, Mathf.Round(InputY), 0f);
            } else {
                if (isLastInputHorizontal) {
                    return new Vector3(0f, Mathf.Round(InputY), 0f);
                } else {
                    return new Vector3(Mathf.Round(InputX), 0f, 0f);
                }
            }
        } else {
            return Vector3.zero;
        }
    }

}
