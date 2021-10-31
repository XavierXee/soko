using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : Singleton<GameEvents>
{
    
    // public event Action<Vector3> OnMoveDone;
    // public event Action<Vector3> OnReplicateNextPosition;

    public event Action<Vector3> onInteract;
    
    // public void MoveDone (Vector3 MoveDirection)
    // {
    //     if (OnMoveDone != null) {
    //         OnMoveDone(MoveDirection);
    //     }
    // }

    // public void ReplicateNextPosition (Vector3 NextPosition)
    // {
    //     if (OnReplicateNextPosition != null) {
    //         OnReplicateNextPosition(NextPosition);
    //     }
    // }

    public void Interact (Vector3 direction)
    {
        onInteract?.Invoke(direction);
        // if (onInteract != null) {
        //     onInteract();
        // }
    }

}
