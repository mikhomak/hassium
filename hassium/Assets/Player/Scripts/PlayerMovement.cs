using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("Stats")] [SerializeField] public float speed;
    [Range(-1, 1)] [SerializeField] private float horInput;
    [Range(-1, 1)] [SerializeField] private float verInput;
    [SerializeField] private bool lockOn;

    [Header("References")] [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField] private IMovement movement;
    [SerializeField] private AnimatorManager animatorManager;


    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        animatorManager = GetComponent<AnimatorManager>();
        movement = new GroundMovement(rigidbody, speed);
    }


    private void FixedUpdate() {
        Vector2 input = InputManager.instance.getAxisInputs();
        movement.movement(input);
        animatorManager.updateMovementParameters(input);
        setInputs(input);
    }

    private void setInputs(Vector2 inputs) {
        horInput = inputs.x;
        verInput = inputs.y;
    }
}