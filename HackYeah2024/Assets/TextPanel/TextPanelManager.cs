using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject textPanel;
    [SerializeField] private TMP_Text textPanelText;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private OptionButton[] optionButtons;
    [SerializeField] private Image skipIndicator;
    [SerializeField] private GameObject TextBox;



    [SerializeField] private float skipIndicatorFadeTime = 0.1f;
    [SerializeField] private float typeSpeed = 0.1f;



    private bool typeInCoroutineGoing = false;
    private string textToType = "";


    private void Update() {
        if (Input.GetButtonDown("Fire1") && typeInCoroutineGoing) {
            SkipTypeInCorutine();
        }
    }

    public void ButtonSelected(int index) {
        Debug.Log($"Button with index:{index} was clicked");
    }

    public void ResetTextUi() {
        textToType = "";
        typeInCoroutineGoing = false;
        foreach (OptionButton button in optionButtons) {
            button.button.gameObject.SetActive(false);
        }
        TextBox.SetActive(false);
    }

    public void ShowTextPanel(string text) {
        TextBox.SetActive(true);
        HideSkipIndicator();
        textPanel.SetActive(true);
        optionsPanel.SetActive(false);
        foreach (OptionButton button in optionButtons) {
            button.button.gameObject.SetActive(false);
        }
        StartCoroutine(TypeTextCoroutine(text));
    }

    public void ShowPanelOptionButtons(string[] buttonText) {
        TextBox.SetActive(true);
        HideSkipIndicator();
        textPanel.SetActive(false);
        optionsPanel.SetActive(true);
        for (int i = 0; i < buttonText.Length; i++) {
            optionButtons[i].text.text = buttonText[i];
            optionButtons[i].button.gameObject.SetActive(true);
        }
    }

    private void SkipTypeInCorutine() {
        if (typeInCoroutineGoing) {
            StopAllCoroutines();
            textPanelText.text = textToType;
            typeInCoroutineGoing = false;
            textToType = "";
            StartCoroutine(FadeInCoroutine(1));
        }
    }

    private void HideSkipIndicator() {
        Color color = skipIndicator.color;
        color.a = 0;
        skipIndicator.color = color;
    }

    private IEnumerator TypeTextCoroutine(string text) {
        typeInCoroutineGoing = true;
        textToType = text;
        textPanelText.text = "";

        float delay = 1f / typeSpeed;
        foreach (char letter in text) {
            textPanelText.text += letter;
            yield return new WaitForSeconds(delay);
        }
        typeInCoroutineGoing = false;
        textToType = "";
        StartCoroutine(FadeInCoroutine(1));
    }

    private IEnumerator FadeInCoroutine(float duration) {
        float elapsedTime = 0f;
        Color color = skipIndicator.color;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / duration);
            skipIndicator.color = color;

            yield return null;
        }
        color.a = 1f;
        skipIndicator.color = color;
    }

}

[Serializable]
public class OptionButton {
    public TMP_Text text;
    public Button button;
}





