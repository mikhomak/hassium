using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class HurtBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == Constants.HITBOX_LAYER) {
            IHitBox hitBox = other.GetComponent<IHitBox>();
            hitBox.takeDamage(0f); //TODO  decide how much damage it would do
        }
    }
}
