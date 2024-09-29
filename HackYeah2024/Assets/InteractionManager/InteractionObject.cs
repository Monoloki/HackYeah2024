using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : InteractionNPC {

    [SerializeField] private int objectIndex;
    [SerializeField] private bool used = false;

    public override void StartInteraction() {
        if (used) return;
        InteractionManager.instance.SetProgress(dialogue, objectIndex);
        used = true;
        //Particle play
    }

    public override bool CanInteract() {
        return InteractionManager.instance.CanInteractObject(dialogue,objectIndex);
    }

}
