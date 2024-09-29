using UnityEngine;
using System.Collections;

public class EmissionBlinker : MonoBehaviour {
    public Material material;                 // Materia�, w kt�rym b�dziemy zmienia� emisj�
    public string emissionColorProperty = "_EmissionColor"; // Nazwa zmiennej koloru emisji w shaderze
    public Color baseEmissionColor = Color.white;  // Bazowy kolor HDR dla emisji
    public float minEmissionIntensity = 1f;        // Minimalna intensywno�� emisji
    public float maxEmissionIntensity = 2f;        // Maksymalna intensywno�� emisji (z HDR)
    public float minBlinkInterval = 0.5f;          // Minimalny czas przerwy mi�dzy miganiem
    public float maxBlinkInterval = 2f;            // Maksymalny czas przerwy mi�dzy miganiem
    public float blinkDuration = 0.5f;             // Czas trwania pojedynczego b�ysku

    private Color currentEmissionColor;

    void Start() {
        // Ustaw kolor emisji pocz�tkowy (bez intensywno�ci)
        currentEmissionColor = baseEmissionColor * minEmissionIntensity;

        // Aktywuj emisj� w materiale (niezb�dne, aby emisja dzia�a�a w URP)
        material.EnableKeyword("_EMISSION");

        // Rozpocznij miganie emisji
        StartCoroutine(BlinkEmission());
    }

    // Korutyna do migania HDR kolorem emisji w nieregularnych odst�pach
    IEnumerator BlinkEmission() {
        while (true) // Niesko�czona p�tla migania
        {
            // Ustaw maksymaln� intensywno�� emisji
            currentEmissionColor = baseEmissionColor * maxEmissionIntensity;
            material.SetColor(emissionColorProperty, currentEmissionColor);

            // Odczekaj czas trwania migania
            yield return new WaitForSeconds(blinkDuration);

            // Ustaw minimaln� intensywno�� emisji
            currentEmissionColor = baseEmissionColor * minEmissionIntensity;
            material.SetColor(emissionColorProperty, currentEmissionColor);

            // Odczekaj losowy czas przerwy przed nast�pnym miganiem
            float randomInterval = Random.Range(minBlinkInterval, maxBlinkInterval);
            yield return new WaitForSeconds(randomInterval);
        }
    }
}