using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUiManager : Singleton<PlayerUiManager>
{
    [SerializeField] private GameObject interactionText;
    [SerializeField] private TMP_Text progressInfo;
    [SerializeField] private float progressFadeTime;

    public void SetInteractionTextUi(bool state) {
        interactionText.SetActive(state);
    }

    public void ShowProgress(int progress, int max) {
        StopAllCoroutines();
        Color color = progressInfo.color;
        color.a = 1f;
        progressInfo.color = color;
        progressInfo.text = $"Progress: {progress}/{max}";
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine() {
        float elapsedTime = 0f;
        Color color = progressInfo.color;
        color.a = 1f;
        progressInfo.color = color;

        while (elapsedTime < progressFadeTime) {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1f - (elapsedTime / progressFadeTime));
            progressInfo.color = color;

            yield return null;
        }

        color.a = 0f;
        progressInfo.color = color;
    }
}
