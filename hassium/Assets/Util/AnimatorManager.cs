﻿using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AnimatorManager : MonoBehaviour {


    private Animator animator;
    private static readonly int HorInput = Animator.StringToHash("horInput");
    private static readonly int VerInput = Animator.StringToHash("verInput");

    private void Start() {
        animator = GetComponentInChildren<Animator>();
    }

    public void updateMovementParameters(Vector2 input) {
        updateMovementParameters(input.x, input.y);
    }

    public void updateMovementParameters(float hor, float ver) {
        animator.SetFloat(VerInput, ver);
        animator.SetFloat(HorInput, hor);
    }


}