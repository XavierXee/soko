using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaController : MonoBehaviour
{
    private Transform Pointer;

    private bool IsControlled;

    private float InputX;
    private float InputY;

    private bool isLastInputHorizontal;

    private Vector3 GetVectorFromInput() {
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
    }

    private bool IsBlocked() {
        return Physics2D.OverlapCircle(Pointer.position + GetVectorFromInput(), .2f, Global.Instance.LayerMaskWall) ||
            Physics2D.OverlapCircle(Pointer.position + GetVectorFromInput(), .2f, Global.Instance.LayerMaskCharacter);
    }

    private void IsFacingCharacter() {

        Debug.Log(Physics2D.OverlapCircle(Pointer.position + GetVectorFromInput(), .2f, Global.Instance.LayerMaskCharacter));
    }

    private void Start() {
        Pointer = GameController.Instance.Pointer;
    }

    public void StartControl() {
        Pointer.position = transform.position;
        IsControlled = true;
    }

    public void StopControl() {
        Pointer = null;
        IsControlled = false;
    }

    private void Update() {
        IsFacingCharacter();
        if (IsControlled) {
            transform.position = Vector3.MoveTowards(transform.position, Pointer.position, Global.Instance.MoveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, Pointer.position) == 0) {
                if (!IsBlocked()) {
                    Pointer.position += GetVectorFromInput();
                }
            }
        }
    }

    public void SetInputValue(float InputXValue, float InputYValue) {
        InputX = InputXValue;
        InputY = InputYValue;
    }
}
