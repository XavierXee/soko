using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    private Collider2D targetCollider;

    public Vector3 lastPosition;

    void Update()
    {
        targetCollider = Physics2D.OverlapCircle(transform.position, .2f);
        if (targetCollider && 
            targetCollider.gameObject.name != GetParentName() &&
            !transform.parent.gameObject.GetComponent<Character>().IsMoving() &&
            lastPosition == transform.position
        ) {
            if (InputHandler.Instance.GetVector() != Vector3.zero) {
                GameEvents.Instance.Interact(InputHandler.Instance.GetVector());
            }
        }
    }

    public void SetLastPosition() {
        lastPosition = transform.position;
    }

    private string GetParentName() {
        return transform.parent.name;
    }
}
