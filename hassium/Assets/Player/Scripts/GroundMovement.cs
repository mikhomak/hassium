using System;
using Player.Scripts;
using UnityEngine;
using Util;

public class GroundMovement : AMovement {
    private bool repeatDirection = false;
    private Vector3 oldForwardDirectionVector;
    private Vector3 oldRightDirectionVector;


    public GroundMovement(Transform transform, CharacterController characterController, Camera camera,
        AnimatorManager animatorManager, float speed) {
        this.characterController = characterController;
        this.speed = speed;
        this.camera = camera;
        this.transform = transform;
        this.animatorManager = animatorManager;
    }

    public override void movement() {
        float minSpeedToMove = new Vector2(horInput, verInput).sqrMagnitude;
        if (minSpeedToMove > allowPlayerRotation) {
            if (lockOn) {
                lockOnMovement();
            }
            else {
                normalMovement();
            }
        }
        else {
            repeatDirection = false;
        }
    }

    private void lockOnMovement() {
        
    }

    private void normalMovement() {
        moveAndRotate();
    }

    private void moveAndRotate() {
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        Vector3 desiredMoveDirection = findDesiredMoveDirection(forward, right);
        if (verInput > 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection),
                desiredRotationSpeed);
        }

        if (Math.Abs(horInput) < Constants.TOLERANCE && Math.Abs(verInput) < Constants.TOLERANCE) {
        }

        characterController.Move(speed * Time.deltaTime * desiredMoveDirection);
    }

    private Vector3 findDesiredMoveDirection(Vector3 forward, Vector3 right) {
        Vector3 direction;
        if (verInput > 0 && Math.Abs(horInput) < Constants.TOLERANCE) {
            direction = forward * verInput + right * horInput;
            repeatDirection = false;
        }
        else {
            if (repeatDirection == false) {
                direction = forward * verInput + right * horInput;
                repeatDirection = true;
                oldForwardDirectionVector = forward;
                oldRightDirectionVector = right;
                transform.rotation = repeatingDirectionRotation(forward, right);
            }
            else {
                animatorManager.lockHeadRotation();
                direction = oldForwardDirectionVector * verInput + oldRightDirectionVector * horInput;
            }
        }


        return direction;
    }

    private Quaternion repeatingDirectionRotation(Vector3 forward, Vector3 right) {
        Vector3 directionToLook;
        if (verInput < 0) {
            directionToLook = -1 * verInput * forward + right * horInput;
        }
        else {
            directionToLook = forward + horInput * right;
        }

        return Quaternion.LookRotation(directionToLook);
    }
}