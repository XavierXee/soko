using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Actor
{

    public bool isControlled;
    public bool isCopying;
    public bool isFollowing;

    private Transform pointer;

    void Awake() {
        //TODO: Instanciate Pointer   
    }

    void Start()
    {
        pointer = transform.GetChild(0);
    }

    void Update()
    {
        if (targetPosition != null) {
            StartMove();
        }
    }

    protected override void StartMove () {
        if (isControlled && InputHandler.Instance.GetVector() != Vector3.zero && !isMoving) {
            originalPosition = transform.position;
            targetPosition = InputHandler.Instance.GetVector();
            pointer.gameObject.GetComponent<Pointer>().SetLastPosition();
            pointer.position = originalPosition + targetPosition;
            StartCoroutine(Move(targetPosition));
        }
    }
}
