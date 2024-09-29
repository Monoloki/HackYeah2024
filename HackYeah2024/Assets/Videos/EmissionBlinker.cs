using UnityEngine;
using System.Collections;

public class EmissionBlinker : MonoBehaviour {
    public Material material;                 // Materia³, w którym bêdziemy zmieniaæ emisjê
    public string emissionColorProperty = "_EmissionColor"; // Nazwa zmiennej koloru emisji w shaderze
    public Color baseEmissionColor = Color.white;  // Bazowy kolor HDR dla emisji
    public float minEmissionIntensity = 1f;        // Minimalna intensywnoœæ emisji
    public float maxEmissionIntensity = 2f;        // Maksymalna intensywnoœæ emisji (z HDR)
    public float minBlinkInterval = 0.5f;          // Minimalny czas przerwy miêdzy miganiem
    public float maxBlinkInterval = 2f;            // Maksymalny czas przerwy miêdzy miganiem
    public float blinkDuration = 0.5f;             // Czas trwania pojedynczego b³ysku

    private Color currentEmissionColor;

    void Start() {
        // Ustaw kolor emisji pocz¹tkowy (bez intensywnoœci)
        currentEmissionColor = baseEmissionColor * minEmissionIntensity;

        // Aktywuj emisjê w materiale (niezbêdne, aby emisja dzia³a³a w URP)
        material.EnableKeyword("_EMISSION");

        // Rozpocznij miganie emisji
        StartCoroutine(BlinkEmission());
    }

    // Korutyna do migania HDR kolorem emisji w nieregularnych odstêpach
    IEnumerator BlinkEmission() {
        while (true) // Nieskoñczona pêtla migania
        {
            // Ustaw maksymaln¹ intensywnoœæ emisji
            currentEmissionColor = baseEmissionColor * maxEmissionIntensity;
            material.SetColor(emissionColorProperty, currentEmissionColor);

            // Odczekaj czas trwania migania
            yield return new WaitForSeconds(blinkDuration);

            // Ustaw minimaln¹ intensywnoœæ emisji
            currentEmissionColor = baseEmissionColor * minEmissionIntensity;
            material.SetColor(emissionColorProperty, currentEmissionColor);

            // Odczekaj losowy czas przerwy przed nastêpnym miganiem
            float randomInterval = Random.Range(minBlinkInterval, maxBlinkInterval);
            yield return new WaitForSeconds(randomInterval);
        }
    }
}