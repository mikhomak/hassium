using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AnimatorManager : MonoBehaviour {
    private Animator animator;
    [SerializeField] private Transform forwardVector;
    private static readonly int HorInput = Animator.StringToHash("horInput");
    private static readonly int VerInput = Animator.StringToHash("verInput");
    private static readonly int LockOn = Animator.StringToHash("lockOn");
    private static readonly int Kick = Animator.StringToHash("kick");

    private void Start() {
        animator = GetComponentInChildren<Animator>();
    }


    public void playAttackAnimation() {
        animator.SetTrigger(Kick);
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