using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class HurtBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == Constants.HITBOX_LAYER) {
            IHitBox hitBox = other.GetComponent<IHitBox>();
            hitBox.takeDamage(0f); //TODO 
        }
    }
}
