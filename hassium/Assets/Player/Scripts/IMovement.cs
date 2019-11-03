using UnityEngine;

public interface IMovement {
    void movement(Vector2 input);
    void movement(float horInput, float verInput);
}