using Player.Scripts;
using UnityEngine;

public class GroundMovement : AMovement {
    public GroundMovement(Rigidbody rigidbody, Camera camera) {
        this.rigidbody = rigidbody;
        this.camera = camera;
    }

    public GroundMovement(Transform transform, Rigidbody rigidbody, Camera camera, float speed) {
        this.rigidbody = rigidbody;
        this.speed = speed;
        this.camera = camera;
        this.transform = transform;
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

        Vector3 desiredMoveDirection = forward * verInput + right * horInput;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection),
            desiredRotationSpeed);
        rigidbody.AddForce(desiredMoveDirection.normalized * speed);
    }
}