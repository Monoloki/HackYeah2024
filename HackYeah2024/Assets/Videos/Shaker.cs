using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public float shakeMagnitude = 0.1f; // Intensywnoœæ trzêsienia

    private Vector3 initialPosition;     // Pocz¹tkowa pozycja obiektu

    void Start() {
        // Zapisz pocz¹tkow¹ pozycjê obiektu
        initialPosition = transform.localPosition;
    }

    void Update() {
        // Generowanie losowej pozycji na podstawie intensywnoœci trzêsienia
        transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
    }
}
