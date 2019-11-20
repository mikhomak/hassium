using System;
using UnityEngine;
using Util;

public class ForwardVectorHeadRotation : MonoBehaviour {
    private float horInput;
    private float verInput;
    private Vector3 oldDirection;
    private Vector3 oldCameraDirection;
    private Camera camera;
    private bool repeatedDirection = false;

    void Start() {
        camera = Camera.main;
    }

    private void FixedUpdate() {
        Vector2 inputs = new Vector2();
        horInput = inputs.x;
        verInput = inputs.y;

        if (verInput > 0 || Math.Abs(horInput) > Constants.TOLERANCE) {
            if (repeatedDirection == false) {
                repeatedDirection = true;
            }
            else {
            }
        }
    }
}