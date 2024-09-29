using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNPC : MonoBehaviour
{
    [SerializeField] protected Quest dialogue;
    [SerializeField] private CinemachineVirtualCamera cameraParent;
    

    public virtual void StartInteraction() {
        InteractionManager.instance.StartInteraction(dialogue);
        CutSceneManager.instance.SwitchToCamera(cameraParent);

    }

    public virtual bool CanInteract() {
        return InteractionManager.instance.CanInteractNPC(dialogue);
    }
}
