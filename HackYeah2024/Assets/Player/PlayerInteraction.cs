using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private InteractionNPC lastActivatedNPC;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Interaction") {
            PlayerUiManager.instance.SetInteractionTextUi(true);
            other.TryGetComponent<InteractionNPC>(out lastActivatedNPC);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Interaction") {
            PlayerUiManager.instance.SetInteractionTextUi(false);
            lastActivatedNPC = null;
        }
    }

    private void Update() {

        if (!GameManager.instance.playerActive) return;

        if (Input.GetKeyDown("e")) {
            lastActivatedNPC.StartInteraction();
            PlayerUiManager.instance.SetInteractionTextUi(false);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 4);
    }
}
