using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public float shakeMagnitude = 0.1f; // Intensywno�� trz�sienia

    private Vector3 initialPosition;     // Pocz�tkowa pozycja obiektu

    void Start() {
        // Zapisz pocz�tkow� pozycj� obiektu
        initialPosition = transform.localPosition;
    }

    void Update() {
        // Generowanie losowej pozycji na podstawie intensywno�ci trz�sienia
        transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
    }
}
