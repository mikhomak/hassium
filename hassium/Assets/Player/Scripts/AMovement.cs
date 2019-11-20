using UnityEngine;

namespace Player.Scripts {
    public class AMovement : IMovement {
        protected float horInput, verInput;
        protected float speed;
        protected bool lockOn = false;
        protected readonly float allowPlayerRotation = 0.1f;
        protected readonly float desiredRotationSpeed = 0.1f;

        /* References */
        protected CharacterController characterController;
        protected Camera camera;
        protected AnimatorManager animatorManager;
        protected Transform transform;
        protected Transform lockOnTargetPosition;

        public virtual void movement() {
        }

        public void setSpeed(float speed) {
            this.speed = speed;
        }

        public void setLockOn(bool lockOn) {
            this.lockOn = lockOn;
        }

        public void setInputs(float horInput, float verInput) {
            this.horInput = horInput;
            this.verInput = verInput;
        }

        public void setInputs(Vector2 input) {
            setInputs(input.x, input.y);
        }

        public void setLockOnTargetPosition(Transform lockOnTargetPosition) {
            this.lockOnTargetPosition = lockOnTargetPosition;
        }
    }
}