using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replicate : Action
{

    private Vector3 NextPosition;

    private void OnEnable() {
        // EventHandler.Instance.OnMoveDone += onControlledCharacterMoveDone;
    }

    // private void OnDisable() {
    //     EventHandler.Instance.OnMoveDone -= onControlledCharacterMoveDone;
    // }

    // private void Update() {
    //     transform.position = Vector3.MoveTowards(transform.position, Pointer.position, Global.Instance.MoveSpeed * Time.deltaTime);
    // }

    // private void onControlledCharacterMoveDone(Vector3 Direction) {
    //     if (!IsBlocked(Pointer.position + Direction)) {
    //         // Pointer.position += Direction;
    //         NextPosition = Pointer.position + Direction;
    //         Pointer.position = NextPosition;
    //         sendNextPositionEvent();
    //     }
    // }

    // private void sendNextPositionEvent() {
    //     EventHandler.Instance.ReplicateNextPosition(NextPosition);
    // }

}
