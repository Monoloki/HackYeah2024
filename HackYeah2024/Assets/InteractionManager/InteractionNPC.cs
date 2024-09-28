using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNPC : MonoBehaviour
{
    [SerializeField] private Quest dialogue;

    public void StartInteraction() {
        InteractionManager.instance.StartInteraction(dialogue);
    }
}
