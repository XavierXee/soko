using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    const string axisHorizontal = "Horizontal";
    const string axisVertical = "Vertical";
    const string layerMaskStopMovement = "StopMovement";

    public Transform previousPosition;
    public Transform followPoint;
    public Transform externalFollowPoint;

	public float moveSpeed = 5f;
    public bool isFollowing = false;

    bool isPlayedCharacter = false;
    bool stopPlayedCharacter = false;

    LayerMask stopMovement;
    Transform movePoint;

    public void StartControl() {
        Init();
    }

    public void StopControl() {
        stopPlayedCharacter = true;
    }

    public void StartFollow() {
        isFollowing = true;
        Init();
    }

    public void StopFollow() {
        isFollowing = false;
    }

    public void SetExternalFollowPoint(Transform extFollowPoint) {
        externalFollowPoint = extFollowPoint;
    }

    public Transform GetFollowPoint() {
        return followPoint;
    }

    void Init() {
        movePoint = isFollowing ? externalFollowPoint : transform.GetChild(0);
        followPoint = transform.GetChild(1);
        movePoint.position = transform.position;
        movePoint.parent = null;
        followPoint.parent = null;
        isPlayedCharacter = true;
        stopPlayedCharacter = false;
    }

    void Reset() {
        movePoint.parent = transform;
        followPoint.parent = transform;
        isPlayedCharacter = false;
        stopPlayedCharacter = false;
    }

    Vector3 GetAxisVector(string axis) {
        return axis == axisVertical ? new Vector3(0f, Input.GetAxisRaw(axis), 0f) : new Vector3(Input.GetAxisRaw(axis), 0f, 0f);
    }

    bool IsStopped(string axis) {
        return axis == null ? false : Physics2D.OverlapCircle(movePoint.position + GetAxisVector(axis), .2f, stopMovement);
    }

    void UpdateMovePointPosition() {
        if (Vector3.Distance(transform.position, movePoint.position) == 0) {
            previousPosition = movePoint;
            if (stopPlayedCharacter) {
                Reset();
            } else {
                string axis = Mathf.Abs(Input.GetAxisRaw(axisHorizontal)) == 1f ? axisHorizontal : axisVertical;
                if (!IsStopped(axis)) {
                    followPoint.position = movePoint.position;
                    movePoint.position += GetAxisVector(axis);
                }
            }
        }
    }

    void MoveCharacterToGrid() {
        if (isPlayedCharacter) {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            UpdateMovePointPosition();
        }
    }

    void Start() {
        stopMovement = LayerMask.GetMask(layerMaskStopMovement);
    }

    void Update() {
        MoveCharacterToGrid();
    }
}
