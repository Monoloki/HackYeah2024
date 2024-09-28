using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUiManager : Singleton<PlayerUiManager>
{
    [SerializeField] private GameObject interactionText;

    public void SetInteractionTextUi(bool state) {
        interactionText.SetActive(state);
    }
}
