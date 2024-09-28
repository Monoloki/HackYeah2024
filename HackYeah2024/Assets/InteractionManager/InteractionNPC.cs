using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNPC : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;

    public void StartInteraction() {
        InteractionManager.instance.StartInteraction();
    }
}
