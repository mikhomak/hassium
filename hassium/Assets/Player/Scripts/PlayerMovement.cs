using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")] [SerializeField] public float speed;
    [Range(-1, 1)] [SerializeField] private float horInput;
    [Range(-1, 1)] [SerializeField] private float verInput;
    [SerializeField] private bool lockOn;

    [Header("References")] [SerializeField]
    private CharacterController characterController;

    [SerializeField] private Camera camera;

    [SerializeField] private IMovement movement;
    [SerializeField] private AnimatorManager animatorManager;


    private void Start()
    {
        setUpReferences();
        movement = new GroundMovement(transform, characterController, camera, animatorManager, speed);
    }

    private void setUpReferences()
    {
        characterController = GetComponent<CharacterController>();
        animatorManager = GetComponentInChildren<AnimatorManager>();
        camera = Camera.main;
    }


    private void FixedUpdate()
    {
        Vector2 input = InputManager.instance.getAxisInputs();
        movement.setInputs(input);
        movement.movement();
        animatorManager.updateMovementParameters(input);
        setInputs(input);
    }

    private void setInputs(Vector2 inputs)
    {
        horInput = inputs.x;
        verInput = inputs.y;
    }
}