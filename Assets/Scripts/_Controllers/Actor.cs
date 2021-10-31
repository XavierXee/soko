using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    protected bool isMoving;
    protected bool isPushed;
    public Vector3 originalPosition, targetPosition = Vector3.zero, pushedDirection = Vector3.zero;
    public float timeToMove;

    public bool interactionGate = true;

    void Start() {
        GameEvents.Instance.onInteract += OnInteract;
    }

    protected virtual void StartMove () {
        StartCoroutine(Move(targetPosition));
    }

    protected IEnumerator Move(Vector3 direction) {
        float elapsedTime = 0;
        originalPosition = transform.position;

        if (
            !(Physics2D.OverlapCircle(originalPosition + direction, .2f, Global.Instance.LayerMaskWall) ||
            Physics2D.OverlapCircle(originalPosition + direction, .2f, Global.Instance.LayerMaskCharacter))
        ) {
            isMoving = true;

            targetPosition = originalPosition + direction;

            while(elapsedTime < timeToMove) {
                // Vector3.MoveTowards(transform.position, targetPosition, (elapsedTime / timeToMove));
                transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
        }

        isMoving = false;
    }

    public bool IsMoving() {
        return isMoving;
    }

    public bool IsBlocked() {
        return Physics2D.OverlapCircle(targetPosition, .2f, Global.Instance.LayerMaskWall) ||
            Physics2D.OverlapCircle(targetPosition, .2f, Global.Instance.LayerMaskCharacter);
    }

    public void OnInteract(Vector3 direction) {
        if (!isMoving) {
            StartCoroutine(Move(InputHandler.Instance.GetVector()));
        }
    }
}
