using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private GameObject lockOnTarget;
    [SerializeField] private PlayerMovement playerMovement;


    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start() {
        playerMovement.setLockOnTarget(lockOnTarget);
    }
}