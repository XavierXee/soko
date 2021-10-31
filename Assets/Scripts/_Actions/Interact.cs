using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [HideInInspector] public Transform InteractPoint;
    public Transform PointerPrefabRed;

    // private void OnEnable() {
    //     if (!GetComponent<Move>().enabled) {
    //         GetComponent<Move>().enabled = true;
    //     }

    //     if (InteractPoint == null) {
    //         InteractPoint = Instantiate(PointerPrefabRed, transform.position, transform.rotation);
    //         InteractPoint.parent = transform;
    //     } else {
    //         InteractPoint.position = transform.position;
    //     }
    // }

    // private void OnDisable()
    // {
    //     if (InteractPoint != null) {
    //         Destroy(InteractPoint);
    //     }
    // }

    // private void Update() {
    //     if (!GetComponent<Move>().Moving) {
    //         if (InputHandler.Instance.GetVector() != Vector3.zero) {
    //             InteractPoint.position = transform.position + InputHandler.Instance.GetVector();
    //         }
    //     }
    // }
}