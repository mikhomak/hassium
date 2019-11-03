using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("Stats")] [SerializeField] private float speed;
    [Range(-1, 1)] [SerializeField] private float horInput;
    [Range(-1, 1)] [SerializeField] private float verInput;

    [Header("References")] [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField] private IMovement movement;


    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        movement = new GroundMovement(rigidbody, speed);
    }


    private void FixedUpdate() {
        movement.movement(InputManager.instance.getAxisInputs());
    }
}