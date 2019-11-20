using UnityEngine;

public interface IMovement
{
    void movement();
    void setSpeed(float speed);
    void setLockOn(bool lockOn);
    void setInputs(float horInput, float verInput);
    void setInputs(Vector2 input);
    void setLockOnTargetPosition(Transform lockOnTargetPosition);
}