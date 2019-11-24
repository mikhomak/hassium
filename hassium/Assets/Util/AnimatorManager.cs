using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AnimatorManager : MonoBehaviour {
    private Animator animator;
    [SerializeField] private Transform forwardVector;
    [SerializeField] private bool Kick;
    private static readonly int HorInput = Animator.StringToHash("horInput");
    private static readonly int VerInput = Animator.StringToHash("verInput");
    private static readonly int LockOn = Animator.StringToHash("lockOn");

    private void Start() {
        animator = GetComponentInChildren<Animator>();
    }


    private void FixedUpdate() {
        if (Input.GetButtonDown("Fire1"))
            animator.SetTrigger("kick");
    }

    public void updateMovementParameters(Vector2 input) {
        updateMovementParameters(input.x, input.y);
    }

    public void updateMovementParameters(float hor, float ver) {
        animator.SetFloat(VerInput, ver);
        animator.SetFloat(HorInput, hor);
    }

    public void lockHeadRotation() {
    }

    private void OnAnimatorIK(int layerIndex) {
        animator.SetLookAtWeight(100);
        animator.SetLookAtPosition(forwardVector.position);
    }
}