using UnityEngine;

public class GroundMovement : IMovement {
    private Rigidbody rigidbody;
    private float speed;
    private bool lockOn;

    public GroundMovement(Rigidbody rigidbody) {
        this.rigidbody = rigidbody;
    }

    public GroundMovement(Rigidbody rigidbody, float speed) {
        this.rigidbody = rigidbody;
        this.speed = speed;
    }

    public void movement(Vector2 input) {
        movement(input.x, input.y);
    }

    public void movement(float horInput, float verInput) {
        if (lockOn) {
            lockOnMovement(horInput, verInput);
        }
        else {
            normalMovement(horInput, verInput);
        }
    }

    private void lockOnMovement(float horInput, float verInput) {
        rigidbody.AddForce(new Vector3(horInput, 0, verInput) * speed);
    }

    private void normalMovement(float horInput, float verInput) {
        
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }

    public void setLockOn(bool lockOn) {
        this.lockOn = lockOn;
    }
}