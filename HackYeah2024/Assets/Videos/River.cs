using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    private int index = 0;

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {

            Destroy(objects[index]);
            index++;
            if (index == objects.Length) {
                StartCoroutine(ChangeShaderColor(startColor, targetColor, duration));
            }
        }
    }

    public Material material;       // Materia³, w którym bêdziemy zmieniaæ zmienn¹ shadera
    public string shaderColorName = "_Color2"; // Nazwa zmiennej koloru w shaderze
    public Color startColor = Color.white;    // Pocz¹tkowy kolor
    public Color targetColor = Color.red;     // Docelowy kolor
    public float duration = 2f;               // Czas trwania zmiany koloru

    // Korutyna zmieniaj¹ca kolor w shaderze
    IEnumerator ChangeShaderColor(Color fromColor, Color toColor, float time) {
        float elapsedTime = 0f;
        while (elapsedTime < time) {
            elapsedTime += Time.deltaTime;

            // Interpolacja koloru i przypisanie go do shadera
            Color currentColor = Color.Lerp(fromColor, toColor, elapsedTime / time);
            material.SetColor(shaderColorName, currentColor);

            // Czekaj do nastêpnej klatki
            yield return null;
        }

        // Upewnij siê, ¿e kolor jest dok³adnie ustawiony na koñcowy
        material.SetColor(shaderColorName, toColor);
    }
}
