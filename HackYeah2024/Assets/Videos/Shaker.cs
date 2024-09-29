using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public float shakeMagnitude = 0.1f; // Intensywność trzęsienia

    private Vector3 initialPosition;     // Początkowa pozycja obiektu

    void Start() {
        // Zapisz początkową pozycję obiektu
        initialPosition = transform.localPosition;
    }

    void Update() {
        // Generowanie losowej pozycji na podstawie intensywności trzęsienia
        transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
    }
}
