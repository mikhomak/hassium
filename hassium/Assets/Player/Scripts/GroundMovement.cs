using Player.Scripts;
using UnityEngine;

public class GroundMovement : AMovement {
    private bool repeatDirection = false;
    private Vector3 oldForwardDirectionVector;
    private Vector3 oldRightDirectionVector;


    public GroundMovement(Transform transform, CharacterController characterController, Camera camera, AnimatorManager animatorManager,float speed) {
        this.characterController = characterController;
        this.speed = speed;
        this.camera = camera;
        this.transform = transform;
        this.animatorManager = animatorManager;
    }

    public override void movement() {
        if (lockOn) {
            lockOnMovement();
        }
        else {
            normalMovement();
        }
    }

    private void lockOnMovement() {
        normalMovement();
    }

    private void normalMovement() {
        float minSpeedToMove = new Vector2(horInput, verInput).sqrMagnitude;
        if (minSpeedToMove > allowPlayerRotation) {
            moveAndRotate();
        }
        else if (minSpeedToMove < allowPlayerRotation) {
        }
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

        characterController.Move(speed * Time.deltaTime * desiredMoveDirection);
    }

    private Vector3 findDesiredMoveDirection(Vector3 forward, Vector3 right) {
        Vector3 direction;
        if (verInput > 0 && horInput == 0) {
            direction = forward * verInput + right * horInput;
            repeatDirection = false;
        }
        else{
            if (repeatDirection == false) {
                direction = forward * verInput + right * horInput;
                repeatDirection = true;
                oldForwardDirectionVector = forward;
                oldRightDirectionVector = right;
            }
            else {
                animatorManager.lockHeadRotation();
                direction = oldForwardDirectionVector * verInput + oldRightDirectionVector * horInput;
            }
        }
        if (horInput == 0 && verInput == 0) {
            repeatDirection = false;
        }

        return direction;
    }
}