using UnityEngine;

namespace Player.Scripts {
    public class AMovement : IMovement {
        protected float horInput, verInput;
        protected float speed;
        protected bool lockOn = true;
        protected float allowPlayerRotation = 0.1f;
        protected float desiredRotationSpeed = 0.1f;
        protected Rigidbody rigidbody;
        protected Camera camera;
        protected Transform transform;

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
    }
}