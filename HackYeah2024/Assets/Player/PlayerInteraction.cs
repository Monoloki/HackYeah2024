using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Interaction") {
            PlayerUiManager.instance.SetInteractionTextUi(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Interaction") {
            PlayerUiManager.instance.SetInteractionTextUi(false);
        }
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 4);
    }
}
