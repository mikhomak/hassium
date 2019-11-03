using UnityEngine;

public class GroundMovement : IMovement {
    private Rigidbody rigidbody;
    private float speed;

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
        rigidbody.AddForce(new Vector3(horInput, 0, verInput) * speed);
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }
}