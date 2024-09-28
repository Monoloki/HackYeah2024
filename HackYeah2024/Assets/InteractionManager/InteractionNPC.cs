using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNPC : MonoBehaviour
{
    [SerializeField] protected Quest dialogue;
    

    public virtual void StartInteraction() {
        InteractionManager.instance.StartInteraction(dialogue);
    }

    public virtual bool CanInteract() {
        return InteractionManager.instance.CanInteractNPC(dialogue);
    }
}
