using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLockOnTarget : MonoBehaviour {


    [SerializeField] private GameObject player;

    [SerializeField] private GameObject enemy;
    

    // Update is called once per frame
    private void FixedUpdate() {
        Vector3 kek  = (player.transform.position - enemy.transform.position);
        kek.Normalize();
        kek.y = 0f;
        transform.position = kek * 2f;
    }
}
