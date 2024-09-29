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

    public Material material;       // Materia�, w kt�rym b�dziemy zmienia� zmienn� shadera
    public string shaderColorName = "_Color2"; // Nazwa zmiennej koloru w shaderze
    public Color startColor = Color.white;    // Pocz�tkowy kolor
    public Color targetColor = Color.red;     // Docelowy kolor
    public float duration = 2f;               // Czas trwania zmiany koloru

    // Korutyna zmieniaj�ca kolor w shaderze
    IEnumerator ChangeShaderColor(Color fromColor, Color toColor, float time) {
        float elapsedTime = 0f;
        while (elapsedTime < time) {
            elapsedTime += Time.deltaTime;

            // Interpolacja koloru i przypisanie go do shadera
            Color currentColor = Color.Lerp(fromColor, toColor, elapsedTime / time);
            material.SetColor(shaderColorName, currentColor);

            // Czekaj do nast�pnej klatki
            yield return null;
        }

        // Upewnij si�, �e kolor jest dok�adnie ustawiony na ko�cowy
        material.SetColor(shaderColorName, toColor);
    }
}
