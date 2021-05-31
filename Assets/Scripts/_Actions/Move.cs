using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [HideInInspector] public Transform MovePoint;
    public Transform PointerPrefabBlue;

    public bool Moving;

    private bool IsBlocked() {
        return Physics2D.OverlapCircle(MovePoint.position + InputHandler.Instance.GetVector(), .2f, Global.Instance.LayerMaskWall) ||
            Physics2D.OverlapCircle(MovePoint.position + InputHandler.Instance.GetVector(), .2f, Global.Instance.LayerMaskCharacter);
    }

    private void OnEnable() {
        if (MovePoint == null) {
            MovePoint = Instantiate(PointerPrefabBlue, transform.position, transform.rotation);
        } else {
            MovePoint.position = transform.position;
        }
    }

    // private void OnDisable()
    // {
    //     if (MovePoint != null) {
    //         Destroy(MovePoint);
    //     }
    // }

    private void Update() {
        Moving = true;
        transform.position = Vector3.MoveTowards(transform.position, MovePoint.position, Global.Instance.MoveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, MovePoint.position) == 0) {
            Moving = false;
            if (!IsBlocked()) {
                MovePoint.position += InputHandler.Instance.GetVector();
            }
        }
    }
}
