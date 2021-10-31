using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : Action
{

    public bool Moving;
    private bool SendEvent;
    private Vector3 LastDirection;
    private Vector3 BlockedPosition;

    public Vector3 Direction;

    private void OnEnable() {
        // EventHandler.Instance.OnReplicateNextPosition += onBlockNextDirectionFromReplicate;
    }

    // private void OnDisable() {
    //     EventHandler.Instance.OnReplicateNextPosition -= onBlockNextDirectionFromReplicate;
    // }

    // private void Update() {
    //     transform.position = Vector3.MoveTowards(transform.position, Pointer.position, Global.Instance.MoveSpeed * Time.deltaTime);
    //     if (Vector3.Distance(transform.position, Pointer.position) == 0) {
    //         // Moving = false;
    //         // if (SendEvent) {
    //             // SendMoveDoneEvent();
    //             // SendEvent = false;
    //         // }
    //         if (!IsBlocked(Pointer.position + InputHandler.Instance.GetVector()) &&
    //             !IsBlocked(BlockedPosition)
    //             ) {
    //             LastDirection = InputHandler.Instance.GetVector();
    //             Pointer.position += LastDirection;
    //         }
    //     } 
    //     // else {
    //     //     Moving = true;
    //     //     SendEvent = true;
    //     // }
    // }

    // private void SendMoveDoneEvent() {
    //     EventHandler.Instance.MoveDone(LastDirection);
    // }

    // private void onBlockNextDirectionFromReplicate(Vector3 Position) {
    //     BlockedPosition = Position;
    // }

}
